using System;

namespace Domain.Core.Models
{
    public class ThirstQuenchingEvent
    {
        public Guid Id { get; set; }
        public Guid PetId { get; set; }
        public DateTime ThirstQuenchingTime { get; set; }
        public float ThirstValueBefore { get; set; }

        public Pet Pet { get; set; }
    }
}
