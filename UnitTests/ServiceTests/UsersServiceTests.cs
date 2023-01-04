using Application.Services.DataTransferObjects;
using Application.Services.DataTransferObjects.Creating;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Services.Exceptions;
using Infrastructure.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class UsersServiceTests
    {
        private Guid userId = Guid.NewGuid();
        private string userPassword = "qwerty";

        private Mock<IFarmsService> farmsServiceMock;
        private Mock<IUsersInfoRepository> usersInfoRepositoryMock;
        private Mock<IRepositoryManager> repositoryManagerMock;
        private Mock<UserManager<User>> userManagerMock;
        private UsersService usersService;

        public UsersServiceTests()
        {
            farmsServiceMock = new Mock<IFarmsService>();

            var store = new Mock<IUserStore<User>>();
            userManagerMock = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            userManagerMock.Object.UserValidators.Add(new UserValidator<User>());
            userManagerMock.Object.PasswordValidators.Add(new PasswordValidator<User>());
            userManagerMock.Setup(e => e.CreateAsync(It.IsAny<User>())).Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            userManagerMock.Setup(e => e.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new User())).Verifiable();
            userManagerMock.Setup(e => e.AddPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            userManagerMock.Setup(e => e.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            userManagerMock.Setup(e => e.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).Returns((User user, string password) => Task.FromResult(password.Equals(userPassword) ? true : false)).Verifiable();
            userManagerMock.Setup(e => e.ChangePasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success)).Verifiable();

            usersInfoRepositoryMock = new Mock<IUsersInfoRepository>();
            usersInfoRepositoryMock.Setup(e => e.CreateUserInfoAsync(It.IsAny<UserInfo>())).Returns(Task.CompletedTask).Verifiable();

            repositoryManagerMock = new Mock<IRepositoryManager>();
            repositoryManagerMock.Setup(e => e.UsersInfo).Returns(usersInfoRepositoryMock.Object);
            repositoryManagerMock.Setup(e => e.SaveChangeAsync()).Returns(Task.CompletedTask);

            var repositoryManager = repositoryManagerMock.Object;


            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<UserCreatingDto, User>(It.IsAny<UserCreatingDto>())).Returns(new User());
            mapperMock.Setup(m => m.Map<UserCreatingDto, UserInfo>(It.IsAny<UserCreatingDto>())).Returns(new UserInfo());


            var inMemorySettings = new Dictionary<string, string> {
                {"Pictures", "{\"avatarPlaceholder\": \"pic.png\"}"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();


            usersService = new UsersService(farmsServiceMock.Object, repositoryManagerMock.Object, userManagerMock.Object, mapperMock.Object, configuration);
        }

        [Fact]
        public async Task CreateUserAsync()
        {
            //Arrange
            var userDto = new UserCreatingDto();

            //Act
            var createdPetId = await usersService.CreateUserAsync(userDto);

            //Assert
            userManagerMock.Verify(e => e.CreateAsync(It.IsAny<User>()));
            userManagerMock.Verify(e => e.AddPasswordAsync(It.IsAny<User>(), It.IsAny<string>()));
            userManagerMock.Verify(e => e.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()));
            usersInfoRepositoryMock.Verify(e => e.CreateUserInfoAsync(It.IsAny<UserInfo>()));
            repositoryManagerMock.Verify(e => e.SaveChangeAsync());
        }

        [Theory]
        [InlineData("wasd123")]
        [InlineData("wasd4uio3pas2j")]
        public async Task ChangePasswordAsync_InvalidOldPassword(string oldPassword)
        {
            //Arrange
            var passwordChangingDto = new PasswordChangingDto() { OldPassword = oldPassword };

            try
            {
                //Act
                await usersService.ChangePasswordAsync(userId, passwordChangingDto);
            }
            catch (AccessException) {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData("qwerty")]
        public async Task ChangePasswordAsync_ValidOldPassword(string oldPassword)
        {
            //Arrange
            var passwordChangingDto = new PasswordChangingDto() { OldPassword = oldPassword };

            try
            {
                //Act
                await usersService.ChangePasswordAsync(userId, passwordChangingDto);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(false);
            }
        }
    }
}
