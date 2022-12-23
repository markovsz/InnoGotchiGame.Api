using Application.Services.DataTransferObjects.Creating;
using FluentValidation;

namespace Infrastructure.Services.Validators
{
    public class PetCreatingDtoValidator : AbstractValidator<PetCreatingDto>
    {
        public PetCreatingDtoValidator()
        {
            RuleFor(e => e.Name).MinimumLength(1).MaximumLength(30);

            RuleFor(e => e.BodyPicName).Matches(@"^body[0-9]+\.svg"); //example: body1.svg 
            RuleFor(e => e.EyesPicName).Matches(@"^eyes[0-9]+\.svg"); 
            RuleFor(e => e.MouthPicName).Matches(@"^mouth[0-9]+\.svg"); 
            RuleFor(e => e.NosePicName).Matches(@"^nose[0-9]+\.svg");

            RuleFor<double>(e => e.BodyPictureScale).GreaterThanOrEqualTo(0.1).LessThanOrEqualTo(5);
            RuleFor<double>(e => e.EyesPictureScale).GreaterThanOrEqualTo(0.1).LessThanOrEqualTo(5);
            RuleFor<double>(e => e.MouthPictureScale).GreaterThanOrEqualTo(0.1).LessThanOrEqualTo(5);
            RuleFor<double>(e => e.NosePictureScale).GreaterThanOrEqualTo(0.1).LessThanOrEqualTo(5);

            RuleFor<double>(e => e.BodyPictureX).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
            RuleFor<double>(e => e.BodyPictureY).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
            RuleFor<double>(e => e.EyesPictureX).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
            RuleFor<double>(e => e.EyesPictureY).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
            RuleFor<double>(e => e.MouthPictureX).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
            RuleFor<double>(e => e.MouthPictureY).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
            RuleFor<double>(e => e.NosePictureX).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
            RuleFor<double>(e => e.NosePictureY).GreaterThanOrEqualTo(-1000).LessThanOrEqualTo(1000);
        }
    }
}
