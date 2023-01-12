using System;

namespace Domain.Core.Models
{
    public class ThirstQuenchingEvent
    {
        public Guid Id { get; set; }
        public Guid PetId { get; set; }
        /// <summary>
        /// Thirst quenching time in pet's seconds
        /// </summary>
        public long ThirstQuenchingTime { get; set; }
        public float ThirstValueBefore { get; set; }

        public Pet Pet { get; set; }
    }
}
