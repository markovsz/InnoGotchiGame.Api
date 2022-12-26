using Application.Services.DataTransferObjects;
using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class UsersService : IUsersService
    {
        private IFarmsService _farmsService;
        private IRepositoryManager _repositoryManager;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public UsersService(IFarmsService farmsService, IRepositoryManager repositoryManager, UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _farmsService = farmsService;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        private string GetErrors(IdentityResult result)
        {
            string res = "";
            foreach(var err in result.Errors){
                res += err;
            }
            return res;
        }

        public async Task<Guid> CreateUserAsync(UserCreatingDto userDto)
        {
            var user = _mapper.Map<UserCreatingDto, User>(userDto);
            user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded) throw new InvalidOperationException(GetErrors(result));
            result = await _userManager.AddPasswordAsync(user, userDto.Password);
            if (!result.Succeeded) throw new InvalidOperationException(GetErrors(result));
            result = await _userManager.AddToRoleAsync(user, UserRoles.User);
            if (!result.Succeeded) throw new InvalidOperationException(GetErrors(result));

            var avatarPlaceholderName = _configuration.GetSection("Pictures").GetSection("avatarPlaceholder").Value;

            var userInfo = _mapper.Map<UserCreatingDto, UserInfo>(userDto);
            userInfo.UserId = user.Id;
            userInfo.PictureSrc = avatarPlaceholderName;
            await _repositoryManager.UsersInfo.CreateUserInfoAsync(userInfo);
            await _repositoryManager.SaveChangeAsync();

            return user.Id;
        }

        public async Task DeleteUserByIdAsync(Guid userId) //TODO: user info deletion
        {
            var userInfo = await _repositoryManager.UsersInfo.GetUserInfoByUserIdAsync(userId, false);
            await _farmsService.DeleteFarmByUserIdAsync(userId);
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) throw new InvalidOperationException(GetErrors(result));
        }

        public async Task<UserReadingDto> GetUserInfoByIdAsync(Guid userId)
        {
            var userInfo = await _repositoryManager.UsersInfo.GetUserInfoByUserIdAsync(userId, false);
            var userInfoDto = _mapper.Map<UserReadingDto>(userInfo);
            return userInfoDto;
        }

        public async Task<UserMinReadingDto> GetMinUserInfoByIdAsync(Guid userId)
        {
            var userInfo = await _repositoryManager.UsersInfo.GetUserInfoByUserIdAsync(userId, false);
            var userInfoDto = _mapper.Map<UserMinReadingDto>(userInfo);
            return userInfoDto;
        }

        public async Task UpdateUserAsync(Guid userId, UserUpdatingDto userDto)
        {
            var userInfo = _mapper.Map<UserInfo>(userDto);
            userInfo.UserId = userId;
            _repositoryManager.UsersInfo.UpdateUserInfo(userInfo);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task UpdateUserAvatarAsync(Guid userId, string avatarPicName)
        {
            var userInfo = await _repositoryManager.UsersInfo.GetUserInfoByUserIdAsync(userId, true);
            userInfo.PictureSrc = avatarPicName;
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task ChangePasswordAsync(Guid userId, PasswordChangingDto passwordChangingDto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var isValidPassword = await _userManager.CheckPasswordAsync(user, passwordChangingDto.OldPassword);
            if (!isValidPassword)
                throw new AccessException("invalid old password");
            var result = await _userManager.ChangePasswordAsync(user, passwordChangingDto.OldPassword, passwordChangingDto.NewPassword);
            if (!result.Succeeded)
                throw new InvalidOperationException("password changing went wrong");
        }
    }
}
