using System;

namespace Application.Services.DataTransferObjects.Creating
{
    public class PetCreatingDto
    {
        public string Name { get; set; }
        public Guid FarmId { get; set; }

        public string BodyPicName { get; set; }
        public string EyesPicName { get; set; }
        public string MouthPicName { get; set; }
        public string NosePicName { get; set; }
    }
}
