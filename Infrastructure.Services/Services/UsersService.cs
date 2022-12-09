using Application.Services.DataTransferObjects;
using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
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

        public UsersService(IFarmsService farmsService, IRepositoryManager repositoryManager, UserManager<User> userManager, IMapper mapper)
        {
            _farmsService = farmsService;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task ChangePasswordAsync(Guid userId, PasswordChangingDto passwordUpdatingDto)
        {
            throw new NotImplementedException();
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
            var user = _mapper.Map<User>(userDto);
            user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded) throw new InvalidOperationException(GetErrors(result));
            result = await _userManager.AddPasswordAsync(user, userDto.Password);
            if (!result.Succeeded) throw new InvalidOperationException(GetErrors(result));
            result = await _userManager.AddToRoleAsync(user, UserRoles.User);
            if (!result.Succeeded) throw new InvalidOperationException(GetErrors(result));

            var userInfoDto = _mapper.Map<UserInfo>(userDto);
            userInfoDto.UserId = user.Id;
            await _repositoryManager.UsersInfo.CreateUserInfoAsync(userInfoDto);
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
    }
}
