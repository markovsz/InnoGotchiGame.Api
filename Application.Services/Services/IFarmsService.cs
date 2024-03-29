﻿using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IFarmsService
    {
        Task<Guid> CreateFarmAsync(Guid userId, FarmCreatingDto farmDto);
        Task<FarmReadingDto> GetFarmByUserIdAsync(Guid userId);
        Task<FarmMinReadingDto> GetMinFarmByUserIdAsync(Guid userId);
        Task<FarmReadingDto> GetFarmByIdAsync(Guid farmId, Guid userId);
        Task<FarmMinReadingDto> GetMinFarmByIdAsync(Guid farmId, Guid userId);
        Task<IEnumerable<FarmMinReadingDto>> GetFriendFarmsAsync(Guid userId);
        Task<IEnumerable<FarmMinReadingDto>> GetFarmsAsync();
        Task UpdateFarmAsync(FarmUpdatingDto farmDto, Guid userId);
        Task DeleteFarmByIdAsync(Guid farmId, Guid userId);
        Task DeleteFarmByUserIdAsync(Guid userId);
    }
}
