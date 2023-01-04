using Application.Services.DataTransferObjects;
using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using System;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IUsersService
    {
        Task<Guid> CreateUserAsync(UserCreatingDto userDto);
        Task<UserReadingDto> GetUserInfoByIdAsync(Guid userId);
        Task<UserMinReadingDto> GetMinUserInfoByIdAsync(Guid userId);
        Task UpdateUserAsync(Guid userId, UserUpdatingDto userDto);
        Task UpdateUserAvatarAsync(Guid userId, string avatarPicName);
        Task ChangePasswordAsync(Guid userId, PasswordChangingDto passwordUpdatingDto);
        Task DeleteUserByIdAsync(Guid userId);
    }
}
