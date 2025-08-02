using CMS.Application.Common.Validator;

namespace CMS.Application.Features.Auth.Commands.ResendConfirmationEmail
{
    public class ResendConfirmationEmailCommandValidator : AbstractValidator<ResendConfirmationEmailCommand>
    {
        public ResendConfirmationEmailCommandValidator()
        {
            RuleFor(r => r.Email)
                .SetValidator(new CustomEmailValidator<ResendConfirmationEmailCommand>());
        }
    }
}
