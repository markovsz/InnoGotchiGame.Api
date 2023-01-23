using System;

namespace Domain.Core.Models
{
    public class FeedingEvent
    {
        public Guid Id { get; set; }
        public Guid PetId { get; set; }
        /// <summary>
        /// Feeding time in pet's seconds
        /// </summary>
        public long FeedingTime { get; set; }
        public float HungerValueBefore { get; set; }

        public Pet Pet { get; set; }
    }
}
