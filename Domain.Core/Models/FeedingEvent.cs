﻿using System;

namespace Domain.Core.Models
{
    public class FeedingEvent
    {
        public Guid Id { get; set; }
        public Guid PetId { get; set; }
        public DateTime FeedingTime { get; set; }
        public float HungerValueBefore { get; set; }

        public Pet Pet { get; set; }
    }
}
