using System;

namespace Application.Services.DataTransferObjects.Reading
{
    public class PetReadingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string HungerLevel { get; set; }
        public string ThirstLevel { get; set; }
        public int HappinessDaysCount { get; set; }
        public string IsAlive { get; set; }

        public string BodyPicName { get; set; }
        public int BodyPictureX { get; set; }
        public int BodyPictureY { get; set; }
        public float BodyPictureScale { get; set; }
        public string EyesPicName { get; set; }
        public int EyesPictureX { get; set; }
        public int EyesPictureY { get; set; }
        public float EyesPictureScale { get; set; }
        public string MouthPicName { get; set; }
        public int MouthPictureX { get; set; }
        public int MouthPictureY { get; set; }
        public float MouthPictureScale { get; set; }
        public string NosePicName { get; set; }
        public int NosePictureX { get; set; }
        public int NosePictureY { get; set; }
        public float NosePictureScale { get; set; }
    }
}
