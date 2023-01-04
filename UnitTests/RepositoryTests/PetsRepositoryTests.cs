using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnitTests.RepositoryTests.Helpers;
using Xunit;

namespace UnitTests.RepositoryTests
{
    public class PetsRepositoryTests
    {
        /*
        private IPetsRepository petsRepository;
        private RepositoryContext context;
        private DateTimeConverter dateTimeConverter;

        private TestDbDataManager dbDataManager;

        public PetsRepositoryTests()
        {
            dateTimeConverter = new DateTimeConverter();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Tests.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;

            context = new RepositoryContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            petsRepository = new PetsRepository(context);

            dbDataManager = new TestDbDataManager(context, dateTimeConverter);
            dbDataManager.Initialize();
        }


        [Theory]
        [InlineData("Pet1", "2022-01-17 22:00:01", 3)]
        [InlineData("Pet1", "2022-01-17 21:50:01", 2)]
        [InlineData("Pet1", "2022-01-17 21:40:01", 2)]
        [InlineData("Pet1", "2022-01-17 21:30:01", 1)]
        [InlineData("Pet1", "2022-01-17 21:20:01", 1)]
        [InlineData("Pet1", "2022-01-17 21:10:01", 1)]
        [InlineData("Pet1", "2022-01-17 21:02:01", 0)]
        public async Task GetPetsAsyncTest(string petName, string currentTimeStr, int happinessDaysCount)
        {
            //Arrange
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var readPets = await petsRepository.GetPetsAsync(currentTime);

            //Assert
            var readPet = readPets.Where(e => e.Name.Equals(petName)).FirstOrDefault();
            Assert.NotNull(readPet);
            var calucatedHappinessDaysCount = readPet.HappinessDaysCount;
            Assert.Equal(happinessDaysCount, calucatedHappinessDaysCount);
            foreach (var pet in readPets)
                Assert.True(pet.DeathDate > currentTime);
        }


        [Theory]
        [InlineData("Pet1", "2022-01-17 22:00:01", 3, "email@gmail.com")]
        [InlineData("Pet1", "2022-01-17 21:50:01", 2, "email@gmail.com")]
        [InlineData("Pet1", "2022-01-17 21:40:01", 2, "email@gmail.com")]
        [InlineData("Pet1", "2022-01-17 21:30:01", 1, "email@gmail.com")]
        [InlineData("Pet1", "2022-01-17 21:20:01", 1, "email@gmail.com")]
        [InlineData("Pet1", "2022-01-17 21:10:01", 1, "email@gmail.com")]
        [InlineData("Pet1", "2022-01-17 21:02:01", 0, "email@gmail.com")]
        public async Task GetUserPetsAsync(string petName, string currentTimeStr, int happinessDaysCount, string userEmail)
        {
            //Arrange
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));
            var user = context.Users.Where(e => e.Email.Equals(userEmail)).FirstOrDefault();

            //Act
            var readPets = await petsRepository.GetUserPetsAsync(user.Id, currentTime);

            //Assert
            var readPet = readPets.Where(e => e.Name.Equals(petName)).FirstOrDefault();
            Assert.NotNull(readPet);
            Assert.NotNull(readPet.Farm);
            Assert.Equal(happinessDaysCount, readPet.HappinessDaysCount);
            foreach (var pet in readPets)
            {
                Assert.Equal(user.Id, pet.Farm.UserId);
            }
        }

        [Theory]
        [InlineData("Farm1", 1)]
        public async Task GetFarmDeadPetsCountAsync(string farmName, int deadPetsCount)
        {
            //Arrange
            var farm = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault();

            //Act
            var calculatedDeadPetsCount = await petsRepository.GetFarmDeadPetsCountAsync(farm.Id);

            //Assert
            Assert.Equal(deadPetsCount, calculatedDeadPetsCount); 
        }

        [Theory]
        [InlineData("Farm1", 3)]
        public async Task GetFarmAlivePetsCountAsync(string farmName, int alivePetsCount)
        {
            //Arrange
            var farm = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault();

            //Act
            var calculatedAlivePetsCount = await petsRepository.GetFarmAlivePetsCountAsync(farm.Id);

            //Assert
            Assert.Equal(alivePetsCount, calculatedAlivePetsCount);
        }

        [Theory]
        [InlineData("Farm1", "2022-01-17 22:00:01", 3.0)]
        public async Task GetFarmAverageHappinessDaysCountAsync(string farmName, string currentTimeStr, double expectedHappinessDaysCount)
        {
            //Arrange
            var farm = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault();
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var calculatedHappinessDaysCount = await petsRepository.GetFarmAverageHappinessDaysCountAsync(farm.Id, currentTime);

            //Assert
            Assert.Equal(expectedHappinessDaysCount, calculatedHappinessDaysCount);
        }

        [Theory]
        [InlineData("Farm1", "2022-01-17 22:00:01", 1.75)]
        public async Task GetFarmAveragePetsAgeAsync(string farmName, string currentTimeStr, double expectedAverageAge)
        {
            //Arrange
            var farm = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault();
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var calculatedAverageAge = await petsRepository.GetFarmAveragePetsAgeAsync(farm.Id, currentTime);

            //Assert
            Assert.Equal(expectedAverageAge, calculatedAverageAge, 0.01);
        }

        [Theory]
        [InlineData("Pet1")]
        [InlineData("Pet2")]
        public async Task GetPetByIdAsync(string petName)
        {
            //Arrange
            var petId = context.Pets.Where(e => e.Name.Equals(petName)).FirstOrDefault().Id;

            //Act
            var readPet = await petsRepository.GetPetByIdAsync(petId, false);

            //Assert
            Assert.Equal(petId, readPet.Id);
            Assert.NotNull(readPet);
            Assert.NotNull(readPet.Farm);
            Assert.NotNull(readPet.Farm.FarmFriends);
            Assert.NotNull(readPet.Body);
            Assert.NotNull(readPet.Eyes);
            Assert.NotNull(readPet.Mouth);
            Assert.NotNull(readPet.Nose);
        }
        */
    }
}
