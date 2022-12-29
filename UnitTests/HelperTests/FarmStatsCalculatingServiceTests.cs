using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Services.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.HelperTests
{
    public class FarmStatsCalculatingServiceTests
    {
        private FarmStatsCalculatingService farmStatsCalculatingService;

        private Guid userId = Guid.NewGuid();
        private Guid friendUserId = Guid.NewGuid();
        private Guid foreignerUserId = Guid.NewGuid();

        private float averageFeedingTime = 1;
        private float averageThirstQuenchingTime = 1;
        private int averageAge = 41;
        private int averageHappinessDaysCount = 21;
        private long now;

        private List<Pet> pets = new List<Pet>();
        private List<Farm> farms = new List<Farm>();

        private Mock<IFeedingFarmStatsService> feedingFarmStatsServiceMock;
        private Mock<IThirstQuenchingFarmStatsService> thirstQuenchingFarmStatsServiceMock;

        private Mock<IPetsRepository> petsRepositoryMock;

        private Mock<IRepositoryManager> repositoryManagerMock;


        public FarmStatsCalculatingServiceTests()
        {
            var dateTimeConverter = new DateTimeConverter();
            now = dateTimeConverter.ConvertToPetsTime(DateTime.Now);


            farms.AddRange(new List<Farm>(){
                new Farm {
                    Id = Guid.NewGuid(),
                    Name = "Octopuses",
                    UserId = userId
                },
                new Farm {
                    Id = Guid.NewGuid(),
                    Name = "Slimes",
                    UserId = friendUserId
                },
                new Farm {
                    Id = Guid.NewGuid(),
                    Name = "Monkes",
                    UserId = foreignerUserId
                },
            });

            pets.AddRange(new List<Pet>(){
                new Pet { Id = Guid.NewGuid(), Name = "Octopus Mike",
                    HungerValue = 80.0f, ThirstValue = 80.0f, HappinessDaysCount = 2,
                    IsAlive = true,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 3)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2023, 03, 29)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = farms[0] },
                new Pet { Id = Guid.NewGuid(), Name = "Octopus Kira",
                    HungerValue = 80.0f, ThirstValue = 80.0f, HappinessDaysCount = 2,
                    IsAlive = true,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 3)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2023, 03, 29)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = farms[1]
                },
                new Pet { Id = Guid.NewGuid(), Name = "Slime Hen",
                    HungerValue = 60.0f, ThirstValue = 60.0f, HappinessDaysCount = 1,
                    IsAlive = true,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 6)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = farms[2] },
                new Pet { Id = Guid.NewGuid(), Name = "Monke Mikael",
                    HungerValue = 60.0f, ThirstValue = 60.0f, HappinessDaysCount = 2,
                    IsAlive = true,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 3)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2023, 03, 29)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = farms[0]
                },
                new Pet { Id = Guid.NewGuid(), Name = "Slime Hent",
                    HungerValue = 20.0f, ThirstValue = 20.0f, HappinessDaysCount = 1,
                    IsAlive = false,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 6)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = farms[2]
                }
            });




            petsRepositoryMock = new Mock<IPetsRepository>();
            petsRepositoryMock.Setup(e => e.GetFarmAlivePetsCountAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(pets.Where(e => e.IsAlive).Count()))
                .Verifiable();
            petsRepositoryMock.Setup(e => e.GetFarmDeadPetsCountAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(pets.Where(e => !e.IsAlive).Count()))
                .Verifiable();
            petsRepositoryMock.Setup(e => e.GetFarmAverageHappinessDaysCountAsync(It.IsAny<Guid>(), It.IsAny<long>()))
                .Returns(Task.FromResult((double)averageHappinessDaysCount))
                .Verifiable();
            petsRepositoryMock.Setup(e => e.GetFarmAveragePetsAgeAsync(It.IsAny<Guid>(), It.IsAny<long>()))
                .Returns(Task.FromResult((double)averageAge))
                .Verifiable();

            repositoryManagerMock = new Mock<IRepositoryManager>();
            repositoryManagerMock.Setup(e => e.Pets).Returns(petsRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.SaveChangeAsync()).Returns(Task.CompletedTask);


            feedingFarmStatsServiceMock = new Mock<IFeedingFarmStatsService>();
            feedingFarmStatsServiceMock.Setup(e => e.GetFarmAverageTimeBetweenFeedingAsync(It.IsAny<Guid>())).Returns(Task.FromResult((double)averageFeedingTime));
            thirstQuenchingFarmStatsServiceMock = new Mock<IThirstQuenchingFarmStatsService>();
            thirstQuenchingFarmStatsServiceMock.Setup(e => e.GetFarmAverageTimeBetweenThirstQuenchingAsync(It.IsAny<Guid>())).Returns(Task.FromResult((double)averageThirstQuenchingTime));

            var petStatsCalculatingService = new PetStatsCalculatingService(dateTimeConverter);

            farmStatsCalculatingService = new FarmStatsCalculatingService(feedingFarmStatsServiceMock.Object, thirstQuenchingFarmStatsServiceMock.Object, repositoryManagerMock.Object);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task UpdateFarmStatsAsync(int farmId)
        {
            //Arrange
            var farmDto = new FarmReadingDto()
            {
                Name = farms[farmId].Name,
                AlivePetsCount = pets.Where(e => e.IsAlive).Count(),
                DeadPetsCount = pets.Where(e => !e.IsAlive).Count(),
                AverageFeedingTime = averageFeedingTime,
                AverageThirstQuenchingTime = averageThirstQuenchingTime,
                AverageHappinessDaysCount = averageHappinessDaysCount,
                AveragePetsAge = averageAge,
                Pets = pets.Where(e => e.Farm.Id.Equals(farms[farmId].Id)).Select(e => new PetReadingDto()).ToList()
            };

            //Act
            var farmReadingDto = await farmStatsCalculatingService.UpdateFarmStatsAsync(farmDto, now);

            //Assert
            petsRepositoryMock.Verify(e => e.GetFarmAlivePetsCountAsync(It.IsAny<Guid>()));
            petsRepositoryMock.Verify(e => e.GetFarmDeadPetsCountAsync(It.IsAny<Guid>()));
            petsRepositoryMock.Verify(e => e.GetFarmAverageHappinessDaysCountAsync(It.IsAny<Guid>(), It.IsAny<long>()));
            petsRepositoryMock.Verify(e => e.GetFarmAveragePetsAgeAsync(It.IsAny<Guid>(), It.IsAny<long>()));
            feedingFarmStatsServiceMock.Verify(e => e.GetFarmAverageTimeBetweenFeedingAsync(It.IsAny<Guid>()));
            thirstQuenchingFarmStatsServiceMock.Verify(e => e.GetFarmAverageTimeBetweenThirstQuenchingAsync(It.IsAny<Guid>()));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task UpdateMinFarmStatsAsync(int petId)
        {
            //Arrange
            var farmDto = new FarmMinReadingDto()
            {
                Name = pets[petId].Name,
                AlivePetsCount = pets.Where(e => e.IsAlive).Count(),
                DeadPetsCount = pets.Where(e => !e.IsAlive).Count(),
                AverageFeedingTime = averageFeedingTime,
                AverageThirstQuenchingTime = averageThirstQuenchingTime,
                AverageHappinessDaysCount = averageHappinessDaysCount,
                AveragePetsAge = averageAge
            };

            //Act
            var farmReadingDto = await farmStatsCalculatingService.UpdateMinFarmStatsAsync(farmDto, now);

            //Assert
            petsRepositoryMock.Verify(e => e.GetFarmAlivePetsCountAsync(It.IsAny<Guid>()));
            petsRepositoryMock.Verify(e => e.GetFarmDeadPetsCountAsync(It.IsAny<Guid>()));
            petsRepositoryMock.Verify(e => e.GetFarmAverageHappinessDaysCountAsync(It.IsAny<Guid>(), It.IsAny<long>()));
            petsRepositoryMock.Verify(e => e.GetFarmAveragePetsAgeAsync(It.IsAny<Guid>(), It.IsAny<long>()));
            feedingFarmStatsServiceMock.Verify(e => e.GetFarmAverageTimeBetweenFeedingAsync(It.IsAny<Guid>()));
            thirstQuenchingFarmStatsServiceMock.Verify(e => e.GetFarmAverageTimeBetweenThirstQuenchingAsync(It.IsAny<Guid>()));
        }
    }
}
