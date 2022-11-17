using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Services.Helpers;
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
        private DateTimeConverter _dateTimeConverter;

        public FeedingEventsService(IRepositoryManager repositoryManager, IMapper mapper, DateTimeConverter dateTimeConverter)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<Guid> CreateFeedingEventAsync(FeedingEventCreatingDto feedingEventDto)
        {
            var feedingEvent = _mapper.Map<FeedingEvent>(feedingEventDto);
            feedingEvent.FeedingTime = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);

            var pet = await _repositoryManager.Pets.GetPetByIdAsync(feedingEventDto.PetId, false);
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

        public async Task<double> GetAverageTimeBetweenFeedingAsync(Guid petId)
        {
            var hungerDays = await _repositoryManager.FeedingEvents.GetHungerDaysAsync(petId);
            var spansBetweenFeeding = new List<double>();
            var hungerDaysEnumerator = hungerDays.GetEnumerator();
            hungerDaysEnumerator.MoveNext();
            var thirstyDayPrev = hungerDaysEnumerator.Current;
            while (hungerDaysEnumerator.MoveNext())
            {
                var thirstyDay = hungerDaysEnumerator.Current;
                spansBetweenFeeding.Add(thirstyDayPrev - thirstyDay);
            }
            return _dateTimeConverter.GetTotalDays((long)spansBetweenFeeding.Average());
        }
    }
}
