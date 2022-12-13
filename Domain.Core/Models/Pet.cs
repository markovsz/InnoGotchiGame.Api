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
            IsAlive = pet.IsAlive;
            HappinessDaysCount = pet.HappinessDaysCount;
            LastPetDetailsUpdatingTime = pet.LastPetDetailsUpdatingTime;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public float HungerValue { get; set; }
        public float ThirstValue { get; set; }
        public long BirthDate { get; set; } //in seconds
        public Guid FarmId { get; set; }
        public bool IsAlive { get; set; }
        public int HappinessDaysCount { get; set; }
        public long LastPetDetailsUpdatingTime { get; set; } //in seconds
        public long DeathDate { get; set; } //in seconds

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
    }
}
