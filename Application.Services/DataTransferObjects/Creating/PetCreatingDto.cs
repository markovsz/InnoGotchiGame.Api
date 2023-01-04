using System;

namespace Application.Services.DataTransferObjects.Creating
{
    public class PetCreatingDto
    {
        public string Name { get; set; }
        public Guid FarmId { get; set; }

        public string BodyPicName { get; set; }
        public float BodyPictureX { get; set; }
        public float BodyPictureY { get; set; }
        public float BodyPictureScale { get; set; }
        public string EyesPicName { get; set; }
        public float EyesPictureX { get; set; }
        public float EyesPictureY { get; set; }
        public float EyesPictureScale { get; set; }
        public string MouthPicName { get; set; }
        public float MouthPictureX { get; set; }
        public float MouthPictureY { get; set; }
        public float MouthPictureScale { get; set; }
        public string NosePicName { get; set; }
        public float NosePictureX { get; set; }
        public float NosePictureY { get; set; }
        public float NosePictureScale { get; set; }
    }
}
