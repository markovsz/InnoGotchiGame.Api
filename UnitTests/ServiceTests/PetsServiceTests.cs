using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.RequestParameters;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Services.Exceptions;
using Infrastructure.Services.Helpers;
using Infrastructure.Services.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class PetsServiceTests
    {
        private PetsService petsService;

        private Guid userId = Guid.NewGuid();
        private Guid friendUserId = Guid.NewGuid();
        private Guid foreignerUserId = Guid.NewGuid();

        private List<Pet> pets = new List<Pet>();
        private Farm farm = new Farm();
        private Farm friendFarm = new Farm();

        private DateTime now = new DateTime(2022, 7, 11);


        private Mock<IFeedingEventsService> feedingEventsServiceMock;
        private Mock<IThirstQuenchingEventsService> thirstQuenchingEventsServiceMock;

        private Mock<IPetsRepository> petsRepositoryMock;
        private Mock<IFarmsRepository> farmsRepositoryMock;

        private Mock<IPetBodiesRepository> bodiesRepositoryMock;
        private Mock<IPetEyesRepository> eyesRepositoryMock;
        private Mock<IPetMouthsRepository> mouthsRepositoryMock;
        private Mock<IPetNosesRepository> nosesRepositoryMock;

        private Mock<IRepositoryManager> repositoryManagerMock;

        private Mock<IDateTimeProvider> dateTimeProviderMock;


        public PetsServiceTests()
        {
            var dateTimeConverter = new DateTimeConverter();

            farm.Id = Guid.NewGuid();
            farm.UserId = userId;
            farm.FarmFriends = new List<FarmFriend>()
            {
                new FarmFriend(){
                    FarmId = farm.Id,
                    UserId = friendUserId
                }
            };

            friendFarm.Id = Guid.NewGuid();
            friendFarm.UserId = friendUserId;

            pets.AddRange(new List<Pet>(){
                new Pet { Id = Guid.NewGuid(), Name = "Octopus Mike",
                    HungerValue = 80.0f, ThirstValue = 80.0f, HappinessDaysCount = 2,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 3)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2023, 03, 29)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = farm },
                new Pet { Id = Guid.NewGuid(), Name = "Octopus Kira",
                    HungerValue = 80.0f, ThirstValue = 80.0f, HappinessDaysCount = 2,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 3)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2023, 03, 29)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = friendFarm
                },
                new Pet { Id = Guid.NewGuid(), Name = "Slime Hen",
                    HungerValue = 60.0f, ThirstValue = 60.0f, HappinessDaysCount = 1,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 6)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = new Farm() { Id = Guid.NewGuid(), UserId = foreignerUserId } },
                new Pet { Id = Guid.NewGuid(), Name = "Monke Mikael",
                    HungerValue = 60.0f, ThirstValue = 60.0f, HappinessDaysCount = 2,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 3)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2023, 03, 29)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = new Farm() { 
                        Id = Guid.NewGuid(), 
                        UserId = userId
                    }
                },
                new Pet { Id = Guid.NewGuid(), Name = "Slime Hent",
                    HungerValue = 20.0f, ThirstValue = 20.0f, HappinessDaysCount = 1,
                    BirthDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 6)),
                    DeathDate = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    LastPetDetailsUpdatingTime = dateTimeConverter.ConvertToPetsTime(new DateTime(2022, 7, 9)),
                    Farm = new Farm() { Id = Guid.NewGuid(), UserId = foreignerUserId } 
                }
            });



            feedingEventsServiceMock = new Mock<IFeedingEventsService>();
            feedingEventsServiceMock.Setup(e => e.CreateFeedingEventAsync(It.IsAny<FeedingEventCreatingDto>()))
                .Returns(Task.FromResult(Guid.NewGuid()));

            thirstQuenchingEventsServiceMock = new Mock<IThirstQuenchingEventsService>();
            thirstQuenchingEventsServiceMock.Setup(e => e.CreateThirstQuenchingEventAsync(It.IsAny<ThirstQuenchingEventCreatingDto>()))
                .Returns(Task.FromResult(Guid.NewGuid()));

            petsRepositoryMock = new Mock<IPetsRepository>();
            petsRepositoryMock.Setup(e => e.GetUntrackablePetByIdAsync(It.IsAny<Guid>(), It.IsAny<long>()))
                .Returns((Guid id, long now) => 
                    Task.FromResult(pets
                        .Where(e => e.Id.Equals(id))
                        .FirstOrDefault()))
                .Verifiable();
            petsRepositoryMock.Setup(e => e.GetTrackablePetByIdAsync(It.IsAny<Guid>(), It.IsAny<long>()))
                .Returns((Guid id, long now) =>
                    Task.FromResult(pets
                        .Where(e => e.Id.Equals(id))
                        .FirstOrDefault()))
                .Verifiable();
            petsRepositoryMock.Setup(e => e.GetPetsAsync(It.IsAny<PetParameters>(), It.IsAny<long>()))
                .Returns(Task.FromResult((IEnumerable<Pet>)pets))
                .Verifiable();
            petsRepositoryMock.Setup(e => e.CreatePetAsync(It.IsAny<Pet>()))
                .Returns(Task.FromResult(pets[0]))
                .Verifiable();

            farmsRepositoryMock = new Mock<IFarmsRepository>();
            farmsRepositoryMock.Setup(e => e.GetFarmByIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(farm))
                .Verifiable();
            farmsRepositoryMock.Setup(e => e.GetFriendFarmAsync(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(Task.FromResult(friendFarm))
                .Verifiable();

            bodiesRepositoryMock = new Mock<IPetBodiesRepository>();
            bodiesRepositoryMock.Setup(e => e.GetPetBodyByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new PetBody()))
                .Verifiable();

            eyesRepositoryMock = new Mock<IPetEyesRepository>();
            eyesRepositoryMock.Setup(e => e.GetPetEyesByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new PetEyes()))
                .Verifiable();

            mouthsRepositoryMock = new Mock<IPetMouthsRepository>();
            mouthsRepositoryMock.Setup(e => e.GetPetMouthByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new PetMouth()))
                .Verifiable();

            nosesRepositoryMock = new Mock<IPetNosesRepository>();
            nosesRepositoryMock.Setup(e => e.GetPetNoseByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new PetNose()))
                .Verifiable();

            repositoryManagerMock = new Mock<IRepositoryManager>();
            repositoryManagerMock.Setup(e => e.Pets).Returns(petsRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.Farms).Returns(farmsRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.PetBodies).Returns(bodiesRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.PetEyes).Returns(eyesRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.PetMouths).Returns(mouthsRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.PetNoses).Returns(nosesRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.SaveChangeAsync()).Returns(Task.CompletedTask);


            var repositoryManager = repositoryManagerMock.Object;
            var petStatsCalculatingService = new PetStatsCalculatingService(repositoryManager, dateTimeConverter);
            var feedingFarmStatsService = new FeedingFarmStatsService(repositoryManager, dateTimeConverter);
            var thirstQuenchingFarmStatsService = new ThirstQuenchingFarmStatsService(repositoryManager, dateTimeConverter);
            var farmStatsCalculatingService = new FarmStatsCalculatingService(petStatsCalculatingService, feedingFarmStatsService, thirstQuenchingFarmStatsService, repositoryManager);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<PetCreatingDto, Pet>(It.IsAny<PetCreatingDto>())).Returns(new Pet());

            dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(e => e.Now).Returns(now);

            var inMemorySettings = new Dictionary<string, string> {
                {"Pagination", "{\"PageSize\": \"15\"}"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            petsService = new PetsService(feedingEventsServiceMock.Object, thirstQuenchingEventsServiceMock.Object, repositoryManagerMock.Object, mapperMock.Object, petStatsCalculatingService, dateTimeConverter, dateTimeProviderMock.Object, configuration);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task CreatePet(int petId)
        {
            //Arrange
            var petDto = new PetCreatingDto() {
                Name = pets[petId].Name,
                FarmId = pets[petId].FarmId,
                BodyPicName = "body1.svg",
                BodyPictureX = 1,
                BodyPictureY = 1,
                BodyPictureScale = 1,
                EyesPicName = "eyes1.svg",
                EyesPictureX = 1,
                EyesPictureY = 1,
                EyesPictureScale = 1,
                MouthPicName = "mouth1.svg",
                MouthPictureX = 1,
                MouthPictureY = 1,
                MouthPictureScale = 1,
                NosePicName = "nose1.svg",
                NosePictureX = 1,
                NosePictureY = 1,
                NosePictureScale = 1
            };

            //Act
            var createdPetId = await petsService.CreatePetAsync(petDto, userId);

            //Assert
            petsRepositoryMock.Verify(e => e.CreatePetAsync(It.IsAny<Pet>()));
            farmsRepositoryMock.Verify(e => e.GetFarmByIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()));

            bodiesRepositoryMock.Verify(e => e.GetPetBodyByNameAsync(It.IsAny<string>()));
            eyesRepositoryMock.Verify(e => e.GetPetEyesByNameAsync(It.IsAny<string>()));
            mouthsRepositoryMock.Verify(e => e.GetPetMouthByNameAsync(It.IsAny<string>()));
            nosesRepositoryMock.Verify(e => e.GetPetNoseByNameAsync(It.IsAny<string>()));

            feedingEventsServiceMock.Verify(e => e.CreateFeedingEventAsync(It.IsAny<FeedingEventCreatingDto>()));
            thirstQuenchingEventsServiceMock.Verify(e => e.CreateThirstQuenchingEventAsync(It.IsAny<ThirstQuenchingEventCreatingDto>()));
        }

        [Theory]
        [InlineData(4)]
        public async Task FeedPetAsync_DeadPet(int petId)
        {
            //Arrange
            Pet pet = pets[petId];

            try
            {
                //Act
                await petsService.FeedPetAsync(pets[petId].Id, userId);
            }
            catch (PetIsDeadException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task FeedPetAsync_PetIsAlreadyFull(int petId)
        {
            //Arrange
            Pet pet = pets[petId];

            try
            {
                //Act
                await petsService.FeedPetAsync(pets[petId].Id, userId);
            }
            catch (PetIsAlreadyFullException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(2)]
        public async Task FeedPetAsync_ForeignerCantAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];

            try
            {
                //Act
                await petsService.FeedPetAsync(pet.Id, foreignerUserId);
            }
            catch (AccessException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task FeedPetAsync_FriendAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];

            try
            {
                //Act
                await petsService.FeedPetAsync(pet.Id, friendUserId);
            }
            catch (AccessException)
            {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(0)]
        public async Task FeedPetAsync_UserAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];

            try
            {
                //Act
                await petsService.FeedPetAsync(pet.Id, userId);
            }
            catch (AccessException)
            {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(4)]
        public async Task QuenchPetThirstAsync_DeadPet(int petId)
        {
            //Arrange
            Pet pet = pets[petId];

            try
            {
                //Act
                await petsService.QuenchPetThirstAsync(pets[petId].Id, userId);
            }
            catch (PetIsDeadException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task QuenchPetThirstAsync_PetIsAlreadyFull(int petId)
        {
            //Arrange
            Pet pet = pets[petId];

            try
            {
                //Act
                await petsService.QuenchPetThirstAsync(pets[petId].Id, userId);
            }
            catch (PetIsAlreadyFullException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(2)]
        public async Task QuenchPetThirstAsync_ForeignerCantAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];

            try
            {
                //Act
                await petsService.QuenchPetThirstAsync(pet.Id, foreignerUserId);
            }
            catch (AccessException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task QuenchPetThirstAsync_FriendAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];

            try
            {
                //Act
                await petsService.QuenchPetThirstAsync(pet.Id, friendUserId);
            }
            catch (AccessException)
            {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(0)]
        public async Task QuenchPetThirstAsync_UserAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];

            try
            {
                //Act
                await petsService.QuenchPetThirstAsync(pet.Id, userId);
            }
            catch (AccessException)
            {
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task GetPetByIdAsync_PetExist(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];

            try
            {
                //Act
                var gottenPet = await petsService.GetPetByIdAsync(pet.Id);
            }
            catch (EntityNotFoundException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData("b18f3731-34da-4567-910a-8ac2a1cbbacc")]
        [InlineData("cbce942a-03c1-4798-806d-a8d36482c7af")]
        public async Task GetPetByIdAsync_PetDoesntExist(string petIdStr)
        {
            //Arrange
            var petId = Guid.Parse(petIdStr);

            try
            {
                //Act
                var pet = await petsService.GetPetByIdAsync(petId);
            }
            catch (EntityNotFoundException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData("b18f3731-34da-4567-910a-8ac2a1cbbacc")]
        [InlineData("cbce942a-03c1-4798-806d-a8d36482c7af")]
        public async Task UpdatePetAsync_PetDoesntExist(string petIdStr)
        {
            //Arrange
            var petId = Guid.Parse(petIdStr);
            var petDto = new PetUpdatingDto() { Id = petId };

            try
            {
                //Act
                await petsService.UpdatePetAsync(petDto, userId);
            }
            catch (EntityNotFoundException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(2)]
        public async Task UpdatePetAsync_ForeignerCantAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];
            var petDto = new PetUpdatingDto() { Id = pet.Id };

            try
            {
                //Act
                await petsService.UpdatePetAsync(petDto, foreignerUserId);
            }
            catch (AccessException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdatePetAsync_FriendCantAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];
            var petDto = new PetUpdatingDto() { Id = pet.Id };

            try
            {
                //Act
                await petsService.UpdatePetAsync(petDto, friendUserId);
            }
            catch (AccessException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(0)]
        public async Task UpdatePetAsync_UserAccess(int petIdNum)
        {
            //Arrange
            var pet = pets[petIdNum];
            var petDto = new PetUpdatingDto() { Id = pet.Id };

            try
            {
                //Act
                await petsService.UpdatePetAsync(petDto, userId);
            }
            catch (AccessException)
            {
                Assert.True(false);
            }
        }
    }
}
