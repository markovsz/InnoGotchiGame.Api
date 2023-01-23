using Application.Services.DataTransferObjects;
using Application.Services.Services;
using Domain.Core.Models;
using Infrastructure.Services.Exceptions;
using Infrastructure.Services.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class AuthServiceTests
    {
        private string userPassword = "qwerty";
        private string userEmail = "email@email.com";

        private Mock<IJwtTokensGeneratorService> jwtTokensGeneratorServiceMock;
        private Mock<UserManager<User>> userManagerMock;
        private AuthService authService;

        public AuthServiceTests()
        {
            jwtTokensGeneratorServiceMock = new Mock<IJwtTokensGeneratorService>();
            jwtTokensGeneratorServiceMock.Setup(e => e.CreateJwtToken(It.IsAny<User>())).Returns(Task.FromResult("jwttoken"));

            var store = new Mock<IUserStore<User>>();
            userManagerMock = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            userManagerMock.Object.UserValidators.Add(new UserValidator<User>());
            userManagerMock.Object.PasswordValidators.Add(new PasswordValidator<User>());
            userManagerMock.Setup(e => e.CreateAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            userManagerMock.Setup(e => e.FindByEmailAsync(It.IsAny<string>()))
                .Returns((string email) => 
                    Task.FromResult(email.Equals(userEmail) ? new User() : null))
                .Verifiable();
            userManagerMock.Setup(e => e.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns((User user, string password) => 
                    Task.FromResult(password.Equals(userPassword) ? true : false))
                .Verifiable();

            authService = new AuthService(userManagerMock.Object, jwtTokensGeneratorServiceMock.Object);
        }

        [Theory]
        [InlineData("email@email.com", "qwerty")]
        public async Task SignInAsync(string email, string password)
        {
            //Arrange
            var passwordChangingDto = new UserAuthenticationDto() { Email = email, Password = password };

            try
            {
                //Act
                var accessDto = await authService.SignInAsync(passwordChangingDto);
            }
            catch (Exception)
            {
                //Assert
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData("email@emai.com", "qwerty")]
        [InlineData("emal@email.com", "qwerty")]
        public async Task SignInAsync_InvalidEmail(string email, string password)
        {
            //Arrange
            var passwordChangingDto = new UserAuthenticationDto() { Email = email, Password = password };

            try
            {
                //Act
                var accessDto = await authService.SignInAsync(passwordChangingDto);
            }
            catch (UserWasntFoundException)
            {
                //Assert
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData("email@email.com", "wasd123")]
        [InlineData("email@email.com", "wasd4uio3pas2j")]
        public async Task SignInAsync_InvalidPassword(string email, string password)
        {
            //Arrange
            var passwordChangingDto = new UserAuthenticationDto() { Email = email, Password = password };

            try
            {
                //Act
                var accessDto = await authService.SignInAsync(passwordChangingDto);
            }
            catch (AccessException)
            {
                //Assert
                Assert.True(true);
            }
        }
    }
}
