using Application.Services.Helpers;
using Domain.Core.Models;
using Infrastructure.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.HelperTests
{
    public class PetStatsCalculatingServiceTests
    {
        private IDateTimeConverter _dateTimeConverter;
        private PetStatsCalculatingService _petStatsCalculatingService;

        public PetStatsCalculatingServiceTests()
        {
            _dateTimeConverter = new DateTimeConverter();
            _petStatsCalculatingService = new PetStatsCalculatingService(_dateTimeConverter);
        }

        [Theory]
        [InlineData("2022-01-09 20:00:00", "2022-01-10 20:00:00", "2022-02-01 20:00:00", false, 0)]
        [InlineData("2022-01-09 20:00:00", "2022-01-17 20:00:00", "2022-02-01 20:00:00", false, 1)]
        [InlineData("2022-01-09 20:00:00", "2022-01-17 20:00:00", "2022-01-12 20:00:00", true, 0)]
        [InlineData("2022-01-09 20:00:00", "2022-01-17 20:00:00", "2022-01-16 21:00:00", true, 1)]
        public void CalculatePetAgeTest(string birthTimeStr, string deathTimeStr, string currentTimeStr, bool isAlive, int expectedAge)
        {
            //Arrange
            var pet = new Pet();
            pet.BirthDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(birthTimeStr));
            pet.DeathDate = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(deathTimeStr));
            pet.IsAlive = isAlive;
            var currentTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var age = _petStatsCalculatingService.CalculatePetAge(pet, currentTime);

            //Assert
            Assert.Equal(expectedAge, age);
        }

        [Theory]
        [InlineData(75.0, "2022-01-10 20:00:00", "2022-01-17 20:00:00", -12.6)]
        [InlineData(80.0, "2022-01-10 20:00:00", "2022-01-11 20:00:00", 67.48572)]
        [InlineData(60.0, "2022-01-10 20:00:00", "2022-01-10 21:00:00", 59.47858)]
        public void CalculateHungerValueAtTimeTest(float hungerValue, string lastPetDetailsUpdatingTimeStr, string currentTimeStr, float expectedHungerValue)
        {
            //Arrange
            var lastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(lastPetDetailsUpdatingTimeStr));
            var currentTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var calculatedHungerValue = _petStatsCalculatingService.CalculateHungerValueAtTime(hungerValue, lastPetDetailsUpdatingTime, currentTime);

            //Assert
            Assert.Equal(expectedHungerValue, calculatedHungerValue, 0.01);
        }

        [Theory]
        [InlineData(75.0, "2022-01-10 20:00:00", "2022-01-17 20:00:00", -12.6)]
        [InlineData(80.0, "2022-01-10 20:00:00", "2022-01-11 20:00:00", 67.48572)]
        [InlineData(60.0, "2022-01-10 20:00:00", "2022-01-10 21:00:00", 59.47858)]
        public void CalculateThirstValueAtTimeTest(float thirstValue, string lastPetDetailsUpdatingTimeStr, string currentTimeStr, float expectedThirstValue)
        {
            //Arrange
            var lastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(lastPetDetailsUpdatingTimeStr));
            var currentTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var calculatedThirstValue = _petStatsCalculatingService.CalculateThirstValueAtTime(thirstValue, lastPetDetailsUpdatingTime, currentTime);

            //Assert
            Assert.Equal(expectedThirstValue, calculatedThirstValue, 0.01);
        }

        [Theory]
        [InlineData(0, "2022-01-10 20:00:00", "2022-01-17 20:00:01", 365)]
        [InlineData(12, "2022-01-10 20:00:00", "2022-01-11 20:00:01", 64)]
        [InlineData(0, "2022-01-10 20:00:00", "2022-01-10 21:00:01", 2)]
        public void GetPetHappinessDaysCountAtTimeTest(int happinessDaysCount, string lastPetDetailsUpdatingTimeStr, string currentTimeStr, int expectedHappinessDaysCount)
        {
            //Arrange
            var lastPetDetailsUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(lastPetDetailsUpdatingTimeStr));
            var currentTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var calculatedHappinessDaysCount = _petStatsCalculatingService.GetPetHappinessDaysCountAtTime(happinessDaysCount, lastPetDetailsUpdatingTime, currentTime);

            //Assert
            Assert.Equal(expectedHappinessDaysCount, calculatedHappinessDaysCount);
        }

        [Theory]
        [InlineData(75, 75, "2022-01-17 20:00:01", 3.99543375)]
        public void CalculateDeathDateTest(float updatedHungerValue, float updatedThirstValue, string currentTimeStr, float expectedAliveDaysCount)
        {
            //Arrange
            var currentTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));
            var expectedDeadTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr).AddDays(expectedAliveDaysCount));

            //Act
            var calculatedDeadTime = _petStatsCalculatingService.CalculateDeathDate(updatedHungerValue, updatedThirstValue, currentTime);

            //Assert
            Assert.Equal(expectedDeadTime, calculatedDeadTime);
        }

        [Theory]
        [InlineData(75.0, 75.0, true, 3, "2022-01-17 19:00:01", "2022-01-21 20:00:01")]
        [InlineData(25.0, 25.0, true, 3, "2022-01-17 19:00:01", "2022-01-17 20:00:01")]
        [InlineData(24.0, 24.0, false, 0, "2022-01-17 19:00:01", "2022-01-17 20:00:01")]
        public void UpdatePetVitalSignsAsyncAsync_PetIsDead(float hungerValue, float thirstValue, bool isAlive, int happinessDaysCount, string lastUpdatingTimeStr, string currentTimeStr)
        {
            //Arrange
            var lastUpdatingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(lastUpdatingTimeStr));
            var currentTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));
            var pet = new Pet()
            {
                HungerValue = hungerValue,
                ThirstValue = thirstValue,
                IsAlive = isAlive,
                HappinessDaysCount = happinessDaysCount,
                LastPetDetailsUpdatingTime = lastUpdatingTime
            };

            //Act
            var updatedPet = _petStatsCalculatingService.UpdatePetVitalSigns(pet, currentTime);

            //Assert
            Assert.False(updatedPet.IsAlive);
            Assert.Equal(0, updatedPet.HappinessDaysCount);
        }
    }
}
