using Application.Services.DataTransferObjects.Updating;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class PetUpdatingDtoValidator : AbstractValidator<PetUpdatingDto>
    {
        public PetUpdatingDtoValidator()
        {
            RuleFor(e => e.Name).MinimumLength(1).MaximumLength(30);
        }
    }
}
