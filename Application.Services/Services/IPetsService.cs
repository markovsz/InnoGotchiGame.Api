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
        Task<Guid> CreatePetAsync(PetCreatingDto petDto, Guid userId);
        Task<string> FeedPetAsync(Guid petId, Guid userId);
        Task<string> QuenchPetThirstAsync(Guid petId, Guid userId);
        Task<PetReadingDto> GetPetByIdAsync(Guid petId);
        Task<IEnumerable<PetReadingDto>> GetUserPetsAsync(Guid userId);
        Task<IEnumerable<PetMinReadingDto>> GetPetsAsync();
        Task UpdatePetAsync(PetUpdatingDto petDto, Guid userId);
        Task DeletePetByIdAsync(Guid petId, Guid userId);
    }
}
