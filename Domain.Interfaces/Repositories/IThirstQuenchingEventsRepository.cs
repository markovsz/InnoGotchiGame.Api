using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IThirstQuenchingEventsRepository
    {
        Task CreateThirstQuenchingEventAsync(ThirstQuenchingEvent thirstQuenchingEvent);
        Task<ThirstQuenchingEvent> GetThirstQuenchingEventByIdAsync(Guid thirstQuenchingEventId, bool trackChanges);
        Task<ThirstQuenchingEvent> GetLastPetThirstQuenchingEventAsync(Guid petId, bool trackChanges);
        Task<IEnumerable<ThirstQuenchingEvent>> GetPetThirstQuenchingEventsAsync(Guid petId);
        Task<IEnumerable<ThirstQuenchingEvent>> GetFarmThirstQuenchingEventsAsync(Guid farmId);
        Task<IEnumerable<long>> GetThirstyDaysAsync(Guid petId);
        void DeleteThirstQuenchingEvent(ThirstQuenchingEvent thirstQuenchingEvent);
    }
}
