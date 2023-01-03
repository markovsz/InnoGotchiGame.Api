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
    public class FarmFriendsRepositoryTests
    {
        /*
        private IFarmFriendsRepository farmFriendsRepository;
        private RepositoryContext context;
        private DateTimeConverter dateTimeConverter;

        private TestDbDataManager dbDataManager;

        public FarmFriendsRepositoryTests()
        {
            dateTimeConverter = new DateTimeConverter();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Tests.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;

            context = new RepositoryContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            farmFriendsRepository = new FarmFriendsRepository(context);

            dbDataManager = new TestDbDataManager(context, dateTimeConverter);
            dbDataManager.Initialize();
        }


        [Theory]
        [InlineData("Farm1", "email2@gmail.com")]
        public async Task GetFarmFriendByIdAsync(string farmName, string friendEmail)
        {
            //Arrange
            var farmId = context.Farms.Where(e => e.Name.Equals(farmName)).FirstOrDefault().Id;
            var farmFriendId = context.FarmFriends
                .Include(e => e.Farm)
                .Include(e => e.UserInfo)
                .Include(e => e.UserInfo.User)
                .Where(e => e.Farm.Name.Equals(farmName) && e.UserInfo.User.Email.Equals(friendEmail)).FirstOrDefault().Id;

            //Act
            var readFarmFriend = await farmFriendsRepository.GetFarmFriendByIdAsync(farmFriendId, false);

            //Assert
            Assert.NotNull(readFarmFriend);
            Assert.Equal(farmFriendId, readFarmFriend.Id);
        }
        */
    }
}
