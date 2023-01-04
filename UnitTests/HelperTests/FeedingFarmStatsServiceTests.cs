using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Services.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.HelperTests
{
    public class FeedingFarmStatsServiceTests
    {
        private FeedingFarmStatsService feedingFarmStatsService;

        private List<FeedingEvent> feedingEvents = new List<FeedingEvent>();

        private Mock<IFeedingEventsRepository> feedingEventsRepositoryMock;

        private Mock<IRepositoryManager> repositoryManagerMock;


        public FeedingFarmStatsServiceTests()
        {
            var dateTimeConverter = new DateTimeConverter();


            feedingEvents.AddRange(new List<FeedingEvent>(){
                new FeedingEvent()
                {
                    Id = Guid.NewGuid(),
                    FeedingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 20:00:01"))
                },
                new FeedingEvent()
                {
                    Id = Guid.NewGuid(),
                    FeedingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01"))
                },
                new FeedingEvent()
                {
                    Id = Guid.NewGuid(),
                    FeedingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 22:00:01"))
                },
                new FeedingEvent()
                {
                    Id = Guid.NewGuid(),
                    FeedingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 22:30:01"))
                },
                new FeedingEvent()
                {
                    Id = Guid.NewGuid(),
                    FeedingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 23:00:01"))
                },
                new FeedingEvent()
                {
                    Id = Guid.NewGuid(),
                    FeedingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-18 08:25:01"))
                },
                new FeedingEvent()
                {
                    Id = Guid.NewGuid(),
                    FeedingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-18 10:00:01"))
                }
            });


            feedingEventsRepositoryMock = new Mock<IFeedingEventsRepository>();
            feedingEventsRepositoryMock.Setup(e => e.GetFarmFeedingEventsAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult((IEnumerable<FeedingEvent>)feedingEvents))
                .Verifiable();

            repositoryManagerMock = new Mock<IRepositoryManager>();
            repositoryManagerMock.Setup(e => e.FeedingEvents).Returns(feedingEventsRepositoryMock.Object);

            feedingFarmStatsService = new FeedingFarmStatsService(repositoryManagerMock.Object, dateTimeConverter);
        }

        [Theory]
        [InlineData(5)] //2.3333 hours
        public async Task GetFarmAverageTimeBetweenFeedingAsync(double expectedAverageTimeBetweenFeeding)
        {
            //Arrange
            var farmId = Guid.NewGuid();

            //Act
            var averageTimeBetweenFeeding = await feedingFarmStatsService.GetFarmAverageTimeBetweenFeedingAsync(farmId);

            //Assert
            Assert.Equal(expectedAverageTimeBetweenFeeding, averageTimeBetweenFeeding, 0.01);
        }
    }
}
