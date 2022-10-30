using System;

namespace Application.Services.DataTransferObjects.Reading
{
    public class FeedingEventReadingDto
    {
        public Guid Id { get; set; }
        public DateTime FeedingTime { get; set; }
        public float HungerValueBefore { get; set; }
    }
}
