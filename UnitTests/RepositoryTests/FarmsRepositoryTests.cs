using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnitTests.RepositoryTests.Helpers;
using Xunit;

namespace UnitTests.RepositoryTests
{
    public class FarmsRepositoryTests
    {
        /*
        private IFarmsRepository farmsRepository;
        private RepositoryContext context;
        private DateTimeConverter dateTimeConverter;

        private TestDbDataManager dbDataManager;

        public FarmsRepositoryTests()
        {
            dateTimeConverter = new DateTimeConverter();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Tests.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;

            context = new RepositoryContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            farmsRepository = new FarmsRepository(context);

            dbDataManager = new TestDbDataManager(context, dateTimeConverter);
            dbDataManager.Initialize();
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
            var readFarm = await farmsRepository.GetFriendFarmAsync(userId, friendId);

            //Assert
            Assert.NotNull(readFarm);
            Assert.NotNull(readFarm.Pets);
        }

        [Theory]
        [InlineData("email@gmail.com")]
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
        */
    }
}
