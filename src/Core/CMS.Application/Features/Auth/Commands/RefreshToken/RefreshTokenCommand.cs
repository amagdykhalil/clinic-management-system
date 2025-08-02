using CMS.Application.Features.Auth.Models;

namespace CMS.Application.Features.Auth.Commands.RefreshToken
{
    public record RefreshTokenCommand(string Token) : ICommand<AuthDTO>;
}


