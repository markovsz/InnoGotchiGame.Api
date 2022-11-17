using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ThirstQuenchingEventsRepository : BaseRepository<ThirstQuenchingEvent>, IThirstQuenchingEventsRepository
    {
        public ThirstQuenchingEventsRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateThirstQuenchingEventAsync(ThirstQuenchingEvent thirstQuenchingEvent) => await CreateAsync(thirstQuenchingEvent);

        public void DeleteThirstQuenchingEvent(ThirstQuenchingEvent thirstQuenchingEvent) => Delete(thirstQuenchingEvent);

        public async Task<ThirstQuenchingEvent> GetThirstQuenchingEventByIdAsync(Guid thirstQuenchingEventId, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(thirstQuenchingEventId), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<ThirstQuenchingEvent>> GetPetThirstQuenchingEventsAsync(Guid petId) =>
            await GetAll(false)
            .Where(e => e.PetId.Equals(petId))
            .ToListAsync();

        public void UpdateThirstQuenchingEvent(ThirstQuenchingEvent thirstQuenchingEvent) => Update(thirstQuenchingEvent);

        public async Task<ThirstQuenchingEvent> GetLastPetThirstQuenchingEventAsync(Guid petId, bool trackChanges) =>
            await GetByCondition(e => e.PetId.Equals(petId), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<long>> GetThirstyDaysAsync(Guid petId) =>
            await GetByCondition(e => e.PetId.Equals(petId), false)
            .Where(e => e.ThirstValueBefore < ThirstLevels.NormalMinThirstValue)
            .Select(e => e.ThirstQuenchingTime)
            .Distinct()
            .ToListAsync();
    }
}
