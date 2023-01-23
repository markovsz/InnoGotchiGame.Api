using Application.Services.DataTransferObjects;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class PasswordChangingDtoValidator : AbstractValidator<PasswordChangingDto>
    {
        public PasswordChangingDtoValidator()
        {
            RuleFor(e => e.OldPassword).MinimumLength(10).MaximumLength(40);
            RuleFor(e => e.NewPassword).MinimumLength(10).MaximumLength(40);
        }
    }
}
