using Application.Services.DataTransferObjects.Creating;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class UserCreatingDtoValidator : AbstractValidator<UserCreatingDto>
    {
        public UserCreatingDtoValidator()
        {
            RuleFor(e => e.FirstName).MinimumLength(1).MaximumLength(20);
            RuleFor(e => e.LastName).MinimumLength(1).MaximumLength(20);
            RuleFor(e => e.Email).EmailAddress();
        }
    }
}
