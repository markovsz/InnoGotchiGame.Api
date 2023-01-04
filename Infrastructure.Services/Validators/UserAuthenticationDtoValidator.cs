using Application.Services.DataTransferObjects;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class UserAuthenticationDtoValidator : AbstractValidator<UserAuthenticationDto>
    {
        public UserAuthenticationDtoValidator()
        {
            RuleFor(e => e.Email).EmailAddress();
        }
    }
}
