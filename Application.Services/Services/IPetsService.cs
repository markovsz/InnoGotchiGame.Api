using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IPetsService
    {
        Task<Guid> CreatePetAsync(PetCreatingDto petDto);
        Task FeedPetAsync(Guid petId);
        Task QuenchPetThirstAsync(Guid petId);
        Task<DateTime> TimeLeftBeforeHungerAsync(Guid petId);
        Task<DateTime> TimeLeftBeforeThirstAsync(Guid petId);
        Task<int> GetHappinessDaysCountAsync(Guid petId);
        Task<PetReadingDto> GetPetByIdAsync(Guid petId);
        Task<IEnumerable<PetReadingDto>> GetUserPetsAsync(Guid userId);
        Task<IEnumerable<PetMinReadingDto>> GetPetsAsync();
        Task UpdatePetAsync(Guid petId, PetUpdatingDto petDto);
        Task DeletePetByIdAsync(Guid petId);
    }
}
