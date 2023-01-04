using System;

namespace Domain.Core.Models
{
    public class ThirstQuenchingEvent
    {
        public Guid Id { get; set; }
        public Guid PetId { get; set; }
        public long ThirstQuenchingTime { get; set; } //in seconds
        public float ThirstValueBefore { get; set; }

        public Pet Pet { get; set; }
    }
}
