using Application.Services.DataTransferObjects.Creating;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class ThirstQuenchingEventsService : IThirstQuenchingEventsService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private IDateTimeConverter _dateTimeConverter;

        public ThirstQuenchingEventsService(IRepositoryManager repositoryManager, IMapper mapper, IDateTimeConverter dateTimeConverter)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<Guid> CreateThirstQuenchingEventAsync(ThirstQuenchingEventCreatingDto thirstQuenchingEventDto)
        {
            var thirstQuenchingEvent = _mapper.Map<ThirstQuenchingEvent>(thirstQuenchingEventDto);
            thirstQuenchingEvent.ThirstQuenchingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);

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
    }
}
