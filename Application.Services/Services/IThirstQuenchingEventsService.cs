using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IThirstQuenchingEventsService
    {
        Task<Guid> CreateThirstQuenchingEventAsync(ThirstQuenchingEventCreatingDto thirstQuenchingEventDto);
        Task<ThirstQuenchingEventReadingDto> GetThirstQuenchingEventByIdAsync(Guid eventId);
        Task<ThirstQuenchingEventReadingDto> GetLastPetThirstQuenchingEventAsync(Guid petId);
        Task<IEnumerable<ThirstQuenchingEventReadingDto>> GetPetThirstQuenchingEventsAsync(Guid petId);
        Task<IEnumerable<DateTime>> GetThirstyDaysAsync(Guid petId);
        Task DeleteThirstQuenchingEventByIdAsync(Guid eventId);
    }
}
