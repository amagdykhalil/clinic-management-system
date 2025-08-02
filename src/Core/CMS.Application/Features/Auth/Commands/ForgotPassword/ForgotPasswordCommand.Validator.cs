using CMS.Application.Common.Validator;

namespace CMS.Application.Features.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(f => f.Email)
                .SetValidator(new CustomEmailValidator<ForgotPasswordCommand>( true));
        }
    }
}
