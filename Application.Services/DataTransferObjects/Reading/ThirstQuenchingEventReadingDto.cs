using System;

namespace Application.Services.DataTransferObjects.Reading
{
    public class ThirstQuenchingEventReadingDto
    {
        public Guid Id { get; set; }
        public DateTime ThirstQuenchingTime { get; set; }
        public float ThirstValueBefore { get; set; }
    }
}
