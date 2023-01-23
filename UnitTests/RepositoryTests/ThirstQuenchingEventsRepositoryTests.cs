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
    public class ThirstQuenchingEventsRepositoryTests
    {
        /*
        private IThirstQuenchingEventsRepository thirstQuenchingEventsRepository;
        private RepositoryContext context;
        private DateTimeConverter dateTimeConverter;

        private TestDbDataManager dbDataManager;

        public ThirstQuenchingEventsRepositoryTests()
        {
            dateTimeConverter = new DateTimeConverter();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Tests.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;

            context = new RepositoryContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
            thirstQuenchingEventsRepository = new ThirstQuenchingEventsRepository(context);

            dbDataManager = new TestDbDataManager(context, dateTimeConverter);
            dbDataManager.Initialize();
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
        */
    }
}
