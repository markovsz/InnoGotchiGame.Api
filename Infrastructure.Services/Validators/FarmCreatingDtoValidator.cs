using Application.Services.DataTransferObjects.Creating;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class FarmCreatingDtoValidator : AbstractValidator<FarmCreatingDto>
    {
        public FarmCreatingDtoValidator()
        {
            RuleFor(e => e.Name).MinimumLength(1).MaximumLength(40);
        }
    }
}
