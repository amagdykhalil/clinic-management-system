using CMS.Application.Abstractions.Infrastructure;
using CMS.Application.Abstractions.Services;
using CMS.Application.Abstractions.UserContext;
using CMS.Domain.Entities;
using CMS.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication;

/// <summary>
/// Implementation of ITokenProvider that generates and manages JWT tokens.
/// </summary>
public sealed class TokenProvider : ITokenProvider
{
    private readonly JWTSettings _jwtSetting;
    private readonly IIdentityService _identityService;
    private readonly IDateTimeProvider _dateTimeProvider;
    public TokenProvider(IOptions<JWTSettings> jwtSettingOptions, IIdentityService identityService, IDateTimeProvider dateTimeProvider = null)
    {
        _jwtSetting = jwtSettingOptions.Value;
        _identityService = identityService;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<string> Create(User user)
    {
        var roles = await _identityService.GetRolesAsync(user.Id);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email)
        };
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtSetting.Issuer,
            Audience = _jwtSetting.Audience,
            IssuedAt = _dateTimeProvider.UtcNow,
            Expires = _dateTimeProvider.UtcNow.AddMinutes(_jwtSetting.AccessTokenExpirationMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret)), SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(claims)
        };

        var SecurityToken = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(SecurityToken);

        return accessToken;
    }

    /// <summary>
    /// Gets the expiration time for access tokens.
    /// </summary>
    /// <returns>The DateTime when the token will expire.</returns>
    public DateTime GetAccessTokenExpiration()
    {
        return _dateTimeProvider.UtcNow.AddMinutes(_jwtSetting.AccessTokenExpirationMinutes);
    }
}




