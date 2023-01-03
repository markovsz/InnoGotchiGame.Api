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
    public class FeedingEventsService : IFeedingEventsService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private IDateTimeConverter _dateTimeConverter;

        public FeedingEventsService(IRepositoryManager repositoryManager, IMapper mapper, IDateTimeConverter dateTimeConverter)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<Guid> CreateFeedingEventAsync(FeedingEventCreatingDto feedingEventDto)
        {
            var feedingEvent = _mapper.Map<FeedingEvent>(feedingEventDto);
            feedingEvent.FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);

            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            var pet = await _repositoryManager.Pets.GetUntrackablePetByIdAsync(feedingEventDto.PetId, now);
            feedingEvent.HungerValueBefore = pet.HungerValue;

            await _repositoryManager.FeedingEvents.CreateFeedingEventAsync(feedingEvent);
            await _repositoryManager.SaveChangeAsync();
            return feedingEvent.Id;
        }

        public async Task DeleteFeedingEventByIdAsync(Guid eventId)
        {
            var feedingEvent = await _repositoryManager.FeedingEvents.GetFeedingEventByIdAsync(eventId, false);
            _repositoryManager.FeedingEvents.DeleteFeedingEvent(feedingEvent);
            await _repositoryManager.SaveChangeAsync();
        }
    }
}
