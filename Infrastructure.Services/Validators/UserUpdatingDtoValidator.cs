using Application.Services.DataTransferObjects.Updating;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class UserUpdatingDtoValidator : AbstractValidator<UserUpdatingDto>
    {
        public UserUpdatingDtoValidator()
        {
            RuleFor(e => e.FirstName).MinimumLength(1).MaximumLength(20);
            RuleFor(e => e.LastName).MinimumLength(1).MaximumLength(20);
        }
    }
}
