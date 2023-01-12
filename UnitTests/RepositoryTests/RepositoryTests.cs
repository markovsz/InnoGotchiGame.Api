using Domain.Interfaces.Repositories;
using Domain.Interfaces.RequestParameters;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.RepositoryTests.Helpers;
using Xunit;

namespace UnitTests.RepositoryTests
{
    public class RepositoryTests
    {
        private IPetsRepository petsRepository;
        private IFarmsRepository farmsRepository;
        private IFarmFriendsRepository farmFriendsRepository;
        private IFeedingEventsRepository feedingEventsRepository;
        private IThirstQuenchingEventsRepository thirstQuenchingEventsRepository;
        private RepositoryContext context;
        private DateTimeConverter dateTimeConverter;

        private TestDbDataManager dbDataManager;

        public RepositoryTests()
        {
            dateTimeConverter = new DateTimeConverter();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Tests.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;

            context = new RepositoryContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            petsRepository = new PetsRepository(context);
            farmsRepository = new FarmsRepository(context);
            farmFriendsRepository = new FarmFriendsRepository(context);
            feedingEventsRepository = new FeedingEventsRepository(context);
            thirstQuenchingEventsRepository = new ThirstQuenchingEventsRepository(context);

            dbDataManager = new TestDbDataManager(context, dateTimeConverter);
            dbDataManager.Initialize();
        }


        [Theory]
        [InlineData("Pet1", "2022-01-17 22:00:01", 2.172619)]
        [InlineData("Pet1", "2022-01-17 21:50:01", 1.810515)]
        [InlineData("Pet1", "2022-01-17 21:40:01", 1.448412)]
        [InlineData("Pet1", "2022-01-17 21:30:01", 1.086309)]
        [InlineData("Pet1", "2022-01-17 21:20:01", 0.724206)]
        [InlineData("Pet1", "2022-01-17 21:10:01", 0.362103)]
        [InlineData("Pet1", "2022-01-17 21:02:01", 0.072420)]
        public async Task GetPetsAsyncTest(string petName, string currentTimeStr, double happinessDaysCount)
        {
            //Arrange
            var parameters = new PetParameters();
            parameters.PageNumber = 1;
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var readPets = await petsRepository.GetPetsAsync(parameters, currentTime);

            //Assert
            var readPet = readPets.Where(e => e.Name.Equals(petName)).FirstOrDefault();
            Assert.NotNull(readPet);
            var calucatedHappinessDaysCount = readPet.HappinessDaysCount;
            Assert.Equal(happinessDaysCount, calucatedHappinessDaysCount, 0.0001);
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
        [InlineData("Farm1", "2022-01-17 22:00:01", 1)]
        public async Task GetFarmDeadPetsCountAsync(string farmName, string currentTimeStr, int deadPetsCount)
        {
            //Arrange
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));
            var farm = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault();

            //Act
            var calculatedDeadPetsCount = await petsRepository.GetFarmDeadPetsCountAsync(farm.Id, currentTime);

            //Assert
            Assert.Equal(deadPetsCount, calculatedDeadPetsCount);
        }

        [Theory]
        [InlineData("Farm1", "2022-01-17 22:00:01", 3)]
        public async Task GetFarmAlivePetsCountAsync(string farmName, string currentTimeStr, int alivePetsCount)
        {
            //Arrange
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));
            var farm = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault();

            //Act
            var calculatedAlivePetsCount = await petsRepository.GetFarmAlivePetsCountAsync(farm.Id, currentTime);

            //Assert
            Assert.Equal(alivePetsCount, calculatedAlivePetsCount);
        }

        [Theory]
        [InlineData("Farm1", "2022-01-17 22:00:01", 2.17262)]
        public async Task GetFarmAverageHappinessDaysCountAsync(string farmName, string currentTimeStr, double expectedHappinessDaysCount)
        {
            //Arrange
            var farm = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault();
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));

            //Act
            var calculatedHappinessDaysCount = await petsRepository.GetFarmAverageHappinessDaysCountAsync(farm.Id, currentTime);

            //Assert
            Assert.Equal(expectedHappinessDaysCount, calculatedHappinessDaysCount, 0.001);
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
        [InlineData("Pet1", "2022-01-17 22:00:01")]
        [InlineData("Pet2", "2022-01-17 22:00:01")]
        public async Task GetPetByIdAsync(string petName, string currentTimeStr)
        {
            //Arrange
            var currentTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse(currentTimeStr));
            var petId = context.Pets.Where(e => e.Name.Equals(petName)).FirstOrDefault().Id;

            //Act
            var readPet = await petsRepository.GetUntrackablePetByIdAsync(petId, currentTime);

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

        [Theory]
        [InlineData("Farm1")]
        public async Task GetFarmByIdAsync(string farmName)
        {
            //Arrange
            var farmId = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault().Id;

            //Act
            var readFarm = await farmsRepository.GetFarmByIdAsync(farmId, false);

            //Assert
            Assert.NotNull(readFarm);
            Assert.NotNull(readFarm.Pets);
            Assert.NotNull(readFarm.UserInfo);
            Assert.NotNull(readFarm.FarmFriends);
            foreach (var farmFriend in readFarm.FarmFriends)
                Assert.NotNull(farmFriend.UserInfo);
        }

        [Theory]
        [InlineData("email@gmail.com")]
        public async Task GetFarmByUserIdAsync(string userEmail)
        {
            //Arrange
            var userId = context.Users.Where(e => e.Email.Equals(userEmail)).FirstOrDefault().Id;

            //Act
            var readFarm = await farmsRepository.GetFarmByUserIdAsync(userId, false);

            //Assert
            Assert.NotNull(readFarm);
            Assert.NotNull(readFarm.Pets);
            Assert.NotNull(readFarm.UserInfo);
            Assert.NotNull(readFarm.FarmFriends);
            foreach (var farmFriend in readFarm.FarmFriends)
                Assert.NotNull(farmFriend.UserInfo);
        }

        [Theory]
        [InlineData("email@gmail.com", "email2@gmail.com")]
        public async Task GetFriendFarmAsync(string userEmail, string friendEmail)
        {
            //Arrange
            var userId = context.Users.Where(e => e.Email.Equals(userEmail)).FirstOrDefault().Id;
            var friendId = context.Users.Where(e => e.Email.Equals(friendEmail)).FirstOrDefault().Id;

            //Act
            var readFarm = await farmsRepository.GetFriendFarmAsync(friendId, userId);

            //Assert
            Assert.NotNull(readFarm);
            Assert.NotNull(readFarm.Pets);
        }

        [Theory]
        [InlineData("email2@gmail.com")]
        public async Task GetFriendFarmsAsync(string userEmail)
        {
            //Arrange
            var userId = context.Users.Where(e => e.Email.Equals(userEmail)).FirstOrDefault().Id;

            //Act
            var readFarms = await farmsRepository.GetFriendFarmsAsync(userId);

            //Assert
            Assert.NotNull(readFarms);
            Assert.NotEmpty(readFarms);
            foreach (var farm in readFarms)
            {
                Assert.NotNull(farm.Pets);
                Assert.NotEmpty(readFarms);
            }
        }

        [Theory]
        [InlineData("Farm1")]
        public async Task GetFarmFeedingEventsAsync(string farmName)
        {
            //Arrange
            var farmId = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault().Id;

            //Act
            var readFeedingEvents = await feedingEventsRepository.GetFarmFeedingEventsAsync(farmId);

            //Assert
            Assert.NotNull(readFeedingEvents);
            Assert.NotEmpty(readFeedingEvents);
            foreach (var feedingEvent in readFeedingEvents)
                Assert.NotNull(feedingEvent.Pet);
        }

        [Theory]
        [InlineData("Farm1")]
        public async Task GetFarmThirstQuenchingEventsAsync(string farmName)
        {
            //Arrange
            var farmId = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault().Id;

            //Act
            var readFeedingEvents = await thirstQuenchingEventsRepository.GetFarmThirstQuenchingEventsAsync(farmId);

            //Assert
            Assert.NotNull(readFeedingEvents);
            Assert.NotEmpty(readFeedingEvents);
            foreach (var feedingEvent in readFeedingEvents)
                Assert.NotNull(feedingEvent.Pet);
        }
    }
}
