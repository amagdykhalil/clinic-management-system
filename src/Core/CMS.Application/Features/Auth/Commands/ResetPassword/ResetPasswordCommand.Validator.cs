using CMS.Application.Common.Validator;
using CMS.Application.Features.Auth.Common;

namespace CMS.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator(
            IIdentityService identityService)
        {
            RuleFor(r => r.Email)
                .SetValidator(new CustomEmailValidator<ResetPasswordCommand>());

            RuleFor(r => r.ResetCode)
                .SetValidator(new CodeValidator<ResetPasswordCommand>());

            RuleFor(r => r.NewPassword)
                .SetAsyncValidator(new PasswordValidator<ResetPasswordCommand>(identityService));
        }
    }
}
