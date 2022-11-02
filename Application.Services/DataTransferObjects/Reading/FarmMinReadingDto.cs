using System;

namespace Application.Services.DataTransferObjects.Reading
{
    public class FarmMinReadingDto
    {
        public string Name { get; set; }
        public int DeadPetsCount { get; set; }
        public int AlivePetsCount { get; set; }
        public TimeSpan AverageFeedingTime { get; set; }
        public TimeSpan AverageThirstQuenchingTime { get; set; }
        public int AverageHappinessDaysCount { get; set; }
        public int AveragePetsAge { get; set; }
    }
}
