using System;
using System.Collections.Generic;

namespace Domain.Core.Models
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float HungerValue { get; set; }
        public float ThirstValue { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid FarmId { get; set; }
        public bool IsAlive { get; set; }
        public int HappinessDaysCount { get; set; }
        public DateTime LastPetDetailsUpdatingTime { get; set; }
        public DateTime DeathDate { get; set; }

        public Farm Farm { get; set; }
        public IEnumerable<FeedingEvent> FeedingEvents { get; set; }
        public IEnumerable<ThirstQuenchingEvent> ThirstQuenchingEvents { get; set; }
    }
}
