using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Updating;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Services.Exceptions;
using Infrastructure.Services.Helpers;
using Infrastructure.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class FarmsServiceTests
    {
        private FarmsService farmsService;

        private Guid userId = Guid.NewGuid();
        private Guid friendUserId = Guid.NewGuid();
        private Guid foreignerUserId = Guid.NewGuid();

        private List<Farm> farms = new List<Farm>();

        private Mock<IFarmsRepository> farmsRepositoryMock;

        private Mock<IRepositoryManager> repositoryManagerMock;


        public FarmsServiceTests()
        {
            var dateTimeConverter = new DateTimeConverter();

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

            farms[0].FarmFriends = new List<FarmFriend>()
            {
                new FarmFriend(){
                    FarmId = farms[0].Id,
                    UserId = friendUserId
                }
            };



            farmsRepositoryMock = new Mock<IFarmsRepository>();
            farmsRepositoryMock.Setup(e => e.GetFarmByIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns((Guid id, bool tc) => 
                    Task.FromResult(
                        farms.Where(e => e.Id.Equals(id))
                        .FirstOrDefault())
                    )
                .Verifiable();
            farmsRepositoryMock.Setup(e => e.GetFarmByUserIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns((Guid id, bool tc) => 
                    Task.FromResult(
                        farms.Where(
                            e => e.UserId.Equals(id))
                        .FirstOrDefault())
                    )
                .Verifiable();
            farmsRepositoryMock.Setup(e => e.GetFriendFarmAsync(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns((Guid userId, Guid friendId) =>
                    Task.FromResult(
                        farms.Where(
                            e => e.UserId.Equals(userId) &&
                            e.FarmFriends
                                .Where(t => t.UserId.Equals(friendId))
                                .Any())
                        .FirstOrDefault())
                    )
                .Verifiable();
            farmsRepositoryMock.Setup(e => e.GetFriendFarmsAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult((IEnumerable<Farm>)new List<Farm>{farms[1]}));

            repositoryManagerMock = new Mock<IRepositoryManager>();
            repositoryManagerMock.Setup(e => e.Farms).Returns(farmsRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.SaveChangeAsync()).Returns(Task.CompletedTask);

            var petStatsCalculatingService = new PetStatsCalculatingService(dateTimeConverter);

            var repositoryManager = repositoryManagerMock.Object;

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<FarmCreatingDto, Farm>(It.IsAny<FarmCreatingDto>())).Returns(new Farm());

            farmsService = new FarmsService(repositoryManagerMock.Object, mapperMock.Object, dateTimeConverter);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task CreatePet(int petId)
        {
            //Arrange
            var farmDto = new FarmCreatingDto()
            {
                Name = farms[petId].Name
            };

            //Act
            var createdPetId = await farmsService.CreateFarmAsync(userId, farmDto);

            //Assert
            farmsRepositoryMock.Verify(e => e.CreateFarmAsync(It.IsAny<Farm>()));
            repositoryManagerMock.Verify(e => e.SaveChangeAsync());
        }

        [Theory]
        [InlineData(0)]
        public async Task GetFarmByIdAsync_UserAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.GetFarmByIdAsync(farm.Id, userId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task GetFarmByIdAsync_FriendCantAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.GetFarmByIdAsync(farm.Id, friendUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(2)]
        public async Task GetFarmByIdAsync_ForeignerCantAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.GetFarmByIdAsync(farm.Id, foreignerUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }


        [Theory]
        [InlineData(0)]
        public async Task GetMinFarmByIdAsync_UserAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.GetMinFarmByIdAsync(farm.Id, userId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task GetMinFarmByIdAsync_FriendAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.GetMinFarmByIdAsync(farm.Id, friendUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(2)]
        public async Task GetMinFarmByIdAsync_ForeignerCantAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.GetMinFarmByIdAsync(farm.Id, foreignerUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }


        [Theory]
        [InlineData(0)]
        public async Task UpdateFarmAsync_UserAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];
            var farmDto = new FarmUpdatingDto() { Id = farm.Id };

            try
            {
                //Act
                await farmsService.UpdateFarmAsync(farmDto, userId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdateFarmAsync_FriendCantAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];
            var farmDto = new FarmUpdatingDto() { Id = farm.Id };

            try
            {
                //Act
                await farmsService.UpdateFarmAsync(farmDto, friendUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(2)]
        public async Task UpdateFarmAsync_ForeignerCantAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];
            var farmDto = new FarmUpdatingDto() { Id = farm.Id };

            try
            {
                //Act
                await farmsService.UpdateFarmAsync(farmDto, foreignerUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }


        [Theory]
        [InlineData(0)]
        public async Task DeleteFarmByIdAsync_UserAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.DeleteFarmByIdAsync(farm.Id, userId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteFarmByIdAsync_FriendAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.DeleteFarmByIdAsync(farm.Id, friendUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(2)]
        public async Task DeleteFarmByIdAsync_ForeignerCantAccess(int farmIdNum)
        {
            //Arrange
            var farm = farms[farmIdNum];

            try
            {
                //Act
                await farmsService.DeleteFarmByIdAsync(farm.Id, foreignerUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }
    }
}
