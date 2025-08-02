using CMS.Application.Common.Validator;
using FluentValidation;

namespace CMS.Application.Features.Auth.Commands.ChangeEmail
{
    public class ChangeEmailCommandValidator : AbstractValidator<ChangeEmailCommand>
    {
        public ChangeEmailCommandValidator()
        {
            RuleFor(x => x.NewEmail)
                .SetValidator(new CustomEmailValidator<ChangeEmailCommand>( true));
        }
    }
} 
