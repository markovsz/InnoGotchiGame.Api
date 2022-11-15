using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class ThirstQuenchingEventsService : IThirstQuenchingEventsService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public ThirstQuenchingEventsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Guid> CreateThirstQuenchingEventAsync(ThirstQuenchingEventCreatingDto thirstQuenchingEventDto)
        {
            var thirstQuenchingEvent = _mapper.Map<ThirstQuenchingEvent>(thirstQuenchingEventDto);
            thirstQuenchingEvent.ThirstQuenchingTime = DateTime.Now;

            var pet = await _repositoryManager.Pets.GetPetByIdAsync(thirstQuenchingEvent.PetId, false);
            thirstQuenchingEvent.ThirstValueBefore = pet.HungerValue;

            await _repositoryManager.ThirstQuenchingEvents.CreateThirstQuenchingEventAsync(thirstQuenchingEvent);
            await _repositoryManager.SaveChangeAsync();

            return thirstQuenchingEvent.Id;
        }

        public async Task DeleteThirstQuenchingEventByIdAsync(Guid eventId)
        {
            var feedingEvent = await _repositoryManager.ThirstQuenchingEvents.GetThirstQuenchingEventByIdAsync(eventId, false);
            _repositoryManager.ThirstQuenchingEvents.DeleteThirstQuenchingEvent(feedingEvent);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<ThirstQuenchingEventReadingDto> GetThirstQuenchingEventByIdAsync(Guid eventId)
        {
            var feedingEvent = await _repositoryManager.ThirstQuenchingEvents.GetThirstQuenchingEventByIdAsync(eventId, false);
            var feedingEventDto = _mapper.Map<ThirstQuenchingEventReadingDto>(feedingEvent);
            return feedingEventDto;
        }

        public async Task<IEnumerable<ThirstQuenchingEventReadingDto>> GetPetThirstQuenchingEventsAsync(Guid petId)
        {
            var feedingEvents = await _repositoryManager.ThirstQuenchingEvents.GetPetThirstQuenchingEventsAsync(petId);
            var feedingEventsDto = _mapper.Map<IEnumerable<ThirstQuenchingEventReadingDto>>(feedingEvents);
            return feedingEventsDto;
        }

        public async Task<ThirstQuenchingEventReadingDto> GetLastPetThirstQuenchingEventAsync(Guid petId)
        {
            var lastThirstQuenchingEvent = await _repositoryManager.ThirstQuenchingEvents.GetLastPetThirstQuenchingEventAsync(petId, false);
            var lastThirstQuenchingEventDto = _mapper.Map<ThirstQuenchingEventReadingDto>(lastThirstQuenchingEvent);
            return lastThirstQuenchingEventDto;
        }

        public async Task<IEnumerable<DateTime>> GetThirstyDaysAsync(Guid petId)
        {
            throw new NotImplementedException();
        }
    }
}
