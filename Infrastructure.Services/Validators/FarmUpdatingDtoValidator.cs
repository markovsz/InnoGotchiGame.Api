using Application.Services.DataTransferObjects.Updating;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class FarmUpdatingDtoValidator : AbstractValidator<FarmUpdatingDto>
    {
        public FarmUpdatingDtoValidator()
        {
            RuleFor(e => e.Name).MinimumLength(1).MaximumLength(40);
        }
    }
}
