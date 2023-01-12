using Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Application.Services.DataTransferObjects.Reading
{
    public class FarmReadingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DeadPetsCount { get; set; }
        public int AlivePetsCount { get; set; }
        /// <summary>
        /// Average feeding time in pet's days
        /// </summary>
        public float AverageFeedingTime { get; set; }
        /// <summary>
        /// Average thirst quenching time in pet's days
        /// </summary>
        public float AverageThirstQuenchingTime { get; set; }
        public int AverageHappinessDaysCount { get; set; }
        public int AveragePetsAge { get; set; }
        public UserMinReadingDto UserInfo { get; set; }

        public IEnumerable<PetReadingDto> Pets { get; set; }
        public IEnumerable<FarmFriendReadingDto> FarmFriends { get; set; }
    }
}
