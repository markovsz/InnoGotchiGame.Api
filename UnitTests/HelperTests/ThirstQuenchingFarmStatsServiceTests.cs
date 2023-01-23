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
    public class ThirstQuenchingFarmStatsServiceTests
    {
        private ThirstQuenchingFarmStatsService feedingFarmStatsService;

        private List<ThirstQuenchingEvent> feedingEvents = new List<ThirstQuenchingEvent>();

        private Mock<IThirstQuenchingEventsRepository> feedingEventsRepositoryMock;

        private Mock<IRepositoryManager> repositoryManagerMock;


        public ThirstQuenchingFarmStatsServiceTests()
        {
            var dateTimeConverter = new DateTimeConverter();


            feedingEvents.AddRange(new List<ThirstQuenchingEvent>(){
                new ThirstQuenchingEvent()
                {
                    Id = Guid.NewGuid(),
                    ThirstQuenchingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 20:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    Id = Guid.NewGuid(),
                    ThirstQuenchingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 21:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    Id = Guid.NewGuid(),
                    ThirstQuenchingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 22:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    Id = Guid.NewGuid(),
                    ThirstQuenchingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 22:30:01"))
                },
                new ThirstQuenchingEvent()
                {
                    Id = Guid.NewGuid(),
                    ThirstQuenchingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-17 23:00:01"))
                },
                new ThirstQuenchingEvent()
                {
                    Id = Guid.NewGuid(),
                    ThirstQuenchingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-18 08:25:01"))
                },
                new ThirstQuenchingEvent()
                {
                    Id = Guid.NewGuid(),
                    ThirstQuenchingTime = dateTimeConverter.ConvertToPetsTime(DateTime.Parse("2022-01-18 10:00:01"))
                }
            });


            feedingEventsRepositoryMock = new Mock<IThirstQuenchingEventsRepository>();
            feedingEventsRepositoryMock.Setup(e => e.GetFarmThirstQuenchingEventsAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult((IEnumerable<ThirstQuenchingEvent>)feedingEvents))
                .Verifiable();

            repositoryManagerMock = new Mock<IRepositoryManager>();
            repositoryManagerMock.Setup(e => e.ThirstQuenchingEvents).Returns(feedingEventsRepositoryMock.Object);

            feedingFarmStatsService = new ThirstQuenchingFarmStatsService(repositoryManagerMock.Object, dateTimeConverter);
        }

        [Theory]
        [InlineData(5)] //2.3333 hours
        public async Task GetFarmAverageTimeBetweenThirstQuenchingAsync(double expectedAverageTimeBetweenThirstQuenching)
        {
            //Arrange
            var farmId = Guid.NewGuid();

            //Act
            var averageTimeBetweenThirstQuenching = await feedingFarmStatsService.GetFarmAverageTimeBetweenThirstQuenchingAsync(farmId);

            //Assert
            Assert.Equal(expectedAverageTimeBetweenThirstQuenching, averageTimeBetweenThirstQuenching, 0.01);
        }
    }
}
