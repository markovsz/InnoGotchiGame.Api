using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
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
    public class FarmFriendsServiceTests
    {
        private Guid userId = Guid.NewGuid();
        private Guid friendUserId = Guid.NewGuid();
        private Guid foreignerUserId = Guid.NewGuid();

        private List<Farm> farms = new List<Farm>();
        private List<FarmFriend> farmFriends = new List<FarmFriend>();

        private Mock<IFarmFriendsRepository> farmFriendsRepositoryMock;
        private Mock<IFarmsRepository> farmsRepositoryMock;

        private Mock<IRepositoryManager> repositoryManagerMock;

        private FarmFriendsService farmFriendsService;

        public FarmFriendsServiceTests()
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

            farmFriends.AddRange(new List<FarmFriend>{
                new FarmFriend(){
                    FarmId = farms[0].Id,
                    UserId = friendUserId
                }
            });



            farmFriendsRepositoryMock = new Mock<IFarmFriendsRepository>();
            farmFriendsRepositoryMock.Setup(e => e.CreateFarmFriendAsync(It.IsAny<FarmFriend>())).Returns(Task.CompletedTask).Verifiable();
            farmFriendsRepositoryMock.Setup(e => e.GetFarmFriendByIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns((Guid ffId, bool tc) => 
                    Task.FromResult(farmFriends
                        .Where(e => e.Id.Equals(ffId))
                        .FirstOrDefault())
                    );
            farmFriendsRepositoryMock.Setup(e => e.DeleteFarmFriend(It.IsAny<FarmFriend>())).Verifiable();

            farmsRepositoryMock = new Mock<IFarmsRepository>();
            farmsRepositoryMock.Setup(e => e.GetFarmByUserIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns((Guid uId, bool tc) => 
                    Task.FromResult(farms
                        .Where(e => e.UserId.Equals(uId))
                        .FirstOrDefault()))
                .Verifiable();

            repositoryManagerMock = new Mock<IRepositoryManager>();
            repositoryManagerMock.Setup(e => e.Farms).Returns(farmsRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.FarmFriends).Returns(farmFriendsRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.SaveChangeAsync()).Returns(Task.CompletedTask);


            var repositoryManager = repositoryManagerMock.Object;
            var petStatsCalculatingService = new PetStatsCalculatingService(repositoryManager, dateTimeConverter);
            

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<IEnumerable<FarmFriend>, IEnumerable<FarmFriendReadingDto>>(It.IsAny<IEnumerable<FarmFriend>>())).Returns(new List<FarmFriendReadingDto>());
            mapperMock.Setup(m => m.Map<FarmFriendCreatingDto, FarmFriend>(It.IsAny<FarmFriendCreatingDto>())).Returns(new FarmFriend());

            farmFriendsService = new FarmFriendsService(repositoryManagerMock.Object, mapperMock.Object);
        }

        [Theory]
        [InlineData(0)]
        public async Task CreateFarmFriendAsync(int farmFriendId)
        {
            //Arrange
            var farmFriendDto = new FarmFriendCreatingDto()
            {
                FarmId = farmFriends[farmFriendId].FarmId,
                UserId = farmFriends[farmFriendId].UserId
            };

            //Act
            var createdPetId = await farmFriendsService.CreateFarmFriendAsync(farmFriendDto, userId); //TODO: return all the object instead of only guid

            //Assert
            farmsRepositoryMock.Verify(e => e.GetFarmByUserIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()));
            farmFriendsRepositoryMock.Verify(e => e.CreateFarmFriendAsync(It.IsAny<FarmFriend>()));
            repositoryManagerMock.Verify(e => e.SaveChangeAsync());
        }

        [Theory]
        [InlineData(0)]
        public async Task DeleteFarmFriendByIdAsync(int farmFriendId)
        {
            //Arrange
            var farmFriend = farmFriends[farmFriendId];

            //Act
            await farmFriendsService.DeleteFarmFriendByIdAsync(farmFriend.Id, userId);

            //Assert
            farmFriendsRepositoryMock.Verify(e => e.DeleteFarmFriend(It.IsAny<FarmFriend>()));
            farmsRepositoryMock.Verify(e => e.GetFarmByUserIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()));
            farmFriendsRepositoryMock.Verify(e => e.GetFarmFriendByIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()));
            repositoryManagerMock.Verify(e => e.SaveChangeAsync());
        }

        [Theory]
        [InlineData(0)]
        public async Task DeleteFarmFriendByIdAsync_UserAccess(int farmFriendId)
        {
            //Arrange
            var farmFriend = farmFriends[farmFriendId];

            try
            {
                //Act
                await farmFriendsService.DeleteFarmFriendByIdAsync(farmFriend.Id, userId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData(0)]
        public async Task DeleteFarmFriendByIdAsync_FriendAccess(int farmFriendId)
        {
            //Arrange
            var farmFriend = farmFriends[farmFriendId];

            try
            {
                //Act
                await farmFriendsService.DeleteFarmFriendByIdAsync(farmFriend.Id, friendUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(0)]
        public async Task DeleteFarmFriendByIdAsync_ForeignerAccess(int farmFriendId)
        {
            //Arrange
            var farmFriend = farmFriends[farmFriendId];

            try
            {
                //Act
                await farmFriendsService.DeleteFarmFriendByIdAsync(farmFriend.Id, friendUserId);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }
    }
}
