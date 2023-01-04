using Domain.Interfaces.Repositories;
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
    public class FeedingEventsRepositoryTests
    {
        /*
        private IFeedingEventsRepository feedingEventsRepository;
        private RepositoryContext context;
        private DateTimeConverter dateTimeConverter;

        private TestDbDataManager dbDataManager;

        public FeedingEventsRepositoryTests()
        {
            dateTimeConverter = new DateTimeConverter();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Tests.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;

            context = new RepositoryContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            feedingEventsRepository = new FeedingEventsRepository(context);

            dbDataManager = new TestDbDataManager(context, dateTimeConverter);
            dbDataManager.Initialize();
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
        */
    }
}
