using CMS.Application.Features.Auth.Commands.Login;

namespace CMS.Application.Tests.Features.Auth.Commands
{
    public class LoginCommandHandlerTests
    {

        private readonly Mock<IIdentityService> _identityServiceMock;
        private readonly Mock<ITokenProvider> _tokenProviderMock;
        private readonly Mock<IRefreshTokenRepository> _refreshTokenRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ILogger<LoginCommandHandler>> _loggerMock;
        private readonly LoginCommandHandler _handler;

        public LoginCommandHandlerTests()
        {
            _identityServiceMock = new Mock<IIdentityService>();
            _tokenProviderMock = new Mock<ITokenProvider>();
            _refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _loggerMock = new Mock<ILogger<LoginCommandHandler>>();

            _handler = new LoginCommandHandler(
                _identityServiceMock.Object,
                _tokenProviderMock.Object,
                _refreshTokenRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task Handle_ValidCredentialsAndNoRefreshToken_ReturnsNewAccessAndRefreshToken()
        {
            // Arrange
            var command = new LoginCommand("test@example.com", "hashedPassword");
            var user = new User { Id = 1, Email = command.Email, DeletedAt = null };
            var accessToken = "access-token";
            var tokenExpiration = DateTime.UtcNow.AddHours(1);

            _identityServiceMock.Setup(x => x.GetUserAsync(command.Email, command.Password, It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _identityServiceMock.Setup(x => x.IsEmailConfirmedAsync(user, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _tokenProviderMock.Setup(x => x.Create(user))
                .ReturnsAsync(accessToken);

            _tokenProviderMock.Setup(x => x.GetAccessTokenExpiration())
                .Returns(tokenExpiration);

            _refreshTokenRepositoryMock.Setup(x => x.GetActiveRefreshTokenAsync(user.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync((RefreshToken?)null);

            var newRefreshToken = new RefreshToken
            {
                Token = "new-refresh-token",
                ExpiresOn = DateTime.UtcNow.AddDays(7)
            };

            _refreshTokenRepositoryMock.Setup(x => x.GenerateRefreshToken(user.Id))
                .Returns(newRefreshToken);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(accessToken, result.Value.AccessToken);
            Assert.Equal(user.Id, result.Value.UserId);
            Assert.Equal(tokenExpiration, result.Value.ExpiresOn);
            Assert.Equal(newRefreshToken.Token, result.Value.RefreshToken);
            Assert.Equal(newRefreshToken.ExpiresOn, result.Value.RefreshTokenExpiration);

            _refreshTokenRepositoryMock.Verify(x => x.AddAsync(It.IsAny<RefreshToken>(), It.IsAny<CancellationToken>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ValidCredentialsAndExistingRefreshToken_ReturnsAccessAndExistingRefreshToken()
        {
            // Arrange
            var command = new LoginCommand("test@example.com", "hashedPassword");
            var user = new User { Id = 1, Email = command.Email, DeletedAt = null };
            var accessToken = "access-token";
            var tokenExpiration = DateTime.UtcNow.AddHours(1);
            var existingRefreshToken = new RefreshToken
            {
                Token = "existing-refresh-token",
                ExpiresOn = DateTime.UtcNow.AddDays(7)
            };

            _identityServiceMock.Setup(x => x.GetUserAsync(command.Email, command.Password, It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _identityServiceMock.Setup(x => x.IsEmailConfirmedAsync(user, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _tokenProviderMock.Setup(x => x.Create(user))
                .ReturnsAsync(accessToken);

            _tokenProviderMock.Setup(x => x.GetAccessTokenExpiration())
                .Returns(tokenExpiration);

            _refreshTokenRepositoryMock.Setup(x => x.GetActiveRefreshTokenAsync(user.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingRefreshToken);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(accessToken, result.Value.AccessToken);
            Assert.Equal(user.Id, result.Value.UserId);
            Assert.Equal(tokenExpiration, result.Value.ExpiresOn);
            Assert.Equal(existingRefreshToken.Token, result.Value.RefreshToken);
            Assert.Equal(existingRefreshToken.ExpiresOn, result.Value.RefreshTokenExpiration);

            _refreshTokenRepositoryMock.Verify(x => x.AddAsync(It.IsAny<RefreshToken>(), It.IsAny<CancellationToken>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_InvalidCredentials_ReturnsError()
        {
            // Arrange
            var command = new LoginCommand("test@example.com", "hashedPassword");

            _identityServiceMock.Setup(x => x.GetUserAsync(command.Email, command.Password, It.IsAny<CancellationToken>()))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);

            _tokenProviderMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            _refreshTokenRepositoryMock.Verify(x => x.GetActiveRefreshTokenAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
            _refreshTokenRepositoryMock.Verify(x => x.AddAsync(It.IsAny<RefreshToken>(), It.IsAny<CancellationToken>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_EmailNotConfirmed_ReturnsUnauthorized()
        {
            // Arrange
            var command = new LoginCommand("test@example.com", "hashedPassword");
            var user = new User { Id = 1, Email = command.Email, DeletedAt = null };

            _identityServiceMock.Setup(x => x.GetUserAsync(command.Email, command.Password, It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _identityServiceMock.Setup(x => x.IsEmailConfirmedAsync(user, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);


            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);

            _tokenProviderMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            _refreshTokenRepositoryMock.Verify(x => x.GetActiveRefreshTokenAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
            _refreshTokenRepositoryMock.Verify(x => x.AddAsync(It.IsAny<RefreshToken>(), It.IsAny<CancellationToken>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_UserDeleted_ReturnsUnauthorized()
        {
            // Arrange
            var command = new LoginCommand("test@example.com", "hashedPassword");
            var user = new User { Id = 1, Email = command.Email, DeletedAt = DateTime.UtcNow };

            _identityServiceMock.Setup(x => x.GetUserAsync(command.Email, command.Password, It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _identityServiceMock.Setup(x => x.IsEmailConfirmedAsync(user, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);

            _tokenProviderMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            _refreshTokenRepositoryMock.Verify(x => x.GetActiveRefreshTokenAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
            _refreshTokenRepositoryMock.Verify(x => x.AddAsync(It.IsAny<RefreshToken>(), It.IsAny<CancellationToken>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
