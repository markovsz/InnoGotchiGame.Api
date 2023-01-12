using System;
using System.Collections.Generic;

namespace Domain.Core.Models
{
    public class Pet
    {
        public Pet() { }

        public Pet(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            HungerValue = pet.HungerValue;
            ThirstValue = pet.ThirstValue;
            BirthDate = pet.BirthDate;
            DeathDate = pet.DeathDate;
            FarmId = pet.FarmId;
            HappinessDaysCount = pet.HappinessDaysCount;
            LastPetDetailsUpdatingTime = pet.LastPetDetailsUpdatingTime;

            BodyId = pet.BodyId;
            BodyPictureScale = pet.BodyPictureScale;
            BodyPictureX = pet.BodyPictureX;
            BodyPictureY = pet.BodyPictureY;
            Body = pet.Body;

            EyesId = pet.EyesId;
            EyesPictureScale = pet.EyesPictureScale;
            EyesPictureX = pet.EyesPictureX;
            EyesPictureY = pet.EyesPictureY;
            Eyes = pet.Eyes;

            MouthId = pet.MouthId;
            MouthPictureScale = pet.MouthPictureScale;
            MouthPictureX = pet.MouthPictureX;
            MouthPictureY = pet.MouthPictureY;
            Mouth = pet.Mouth;

            NoseId = pet.NoseId;
            NosePictureScale = pet.NosePictureScale;
            NosePictureX = pet.NosePictureX;
            NosePictureY = pet.NosePictureY;
            Nose = pet.Nose;

            Farm = pet.Farm;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public float HungerValue { get; set; }
        public float ThirstValue { get; set; }
        /// <summary>
        /// Birth date in pet's seconds
        /// </summary>
        public long BirthDate { get; set; }
        public Guid FarmId { get; set; }
        /// <summary>
        /// Happiness days count in pet's days
        /// </summary>
        public double HappinessDaysCount { get; set; }
        /// <summary>
        /// The last pet's details updating time in pet's seconds
        /// </summary>
        public long LastPetDetailsUpdatingTime { get; set; }
        /// <summary>
        /// Death date in pet's seconds
        /// </summary>
        public long DeathDate { get; set; }

        public Guid BodyId { get; set; }
        public float BodyPictureX { get; set; }
        public float BodyPictureY { get; set; }
        public float BodyPictureScale { get; set; }
        public Guid EyesId { get; set; }
        public float EyesPictureX { get; set; }
        public float EyesPictureY { get; set; }
        public float EyesPictureScale { get; set; }
        public Guid NoseId { get; set; }
        public float NosePictureX { get; set; }
        public float NosePictureY { get; set; }
        public float NosePictureScale { get; set; }
        public Guid MouthId { get; set; }
        public float MouthPictureX { get; set; }
        public float MouthPictureY { get; set; }
        public float MouthPictureScale { get; set; }

        public Farm Farm { get; set; }
        public IEnumerable<FeedingEvent> FeedingEvents { get; set; }
        public IEnumerable<ThirstQuenchingEvent> ThirstQuenchingEvents { get; set; }
        public PetBody Body { get; set; }
        public PetEyes Eyes { get; set; }
        public PetNose Nose { get; set; }
        public PetMouth Mouth { get; set; }

        public bool IsAlive(long now) {
            return now < DeathDate;
        }
    }
}
