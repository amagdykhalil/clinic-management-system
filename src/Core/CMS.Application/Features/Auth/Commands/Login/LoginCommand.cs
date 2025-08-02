using CMS.Application.Features.Auth.Models;

namespace CMS.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password) : ICommand<AuthDTO>;
}


