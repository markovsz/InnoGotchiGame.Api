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

        public Farm Farm { get; set; }
        public IEnumerable<FeedingEvent> FeedingEvents { get; set; }
        public IEnumerable<ThirstQuenchingEvent> ThirstQuenchingEvents { get; set; }
    }
}
