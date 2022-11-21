using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Infrastructure.Services.Helpers;
using Infrastructure.Services.Exceptions;

namespace Infrastructure.Services.Services
{
    public class PetsService : IPetsService
    {
        private IFeedingEventsService _feedingEventsService;
        private IThirstQuenchingEventsService _thirstQuenchingEventsService;
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private DateTimeConverter _dateTimeConverter;

        public PetsService(IFeedingEventsService feedingEventsService, IThirstQuenchingEventsService thirstQuenchingEventsService, IRepositoryManager repositoryManager, IMapper mapper, DateTimeConverter dateTimeConverter)
        {
            _feedingEventsService = feedingEventsService;
            _thirstQuenchingEventsService = thirstQuenchingEventsService;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<Guid> CreatePetAsync(PetCreatingDto petDto, Guid userId)
        {
            var user = await _repositoryManager.Farms.GetFarmByIdAsync(petDto.FarmId, false);
            if (user.UserId != userId)
                throw new InvalidOperationException("you don't have permissions");

            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);

            var pet = _mapper.Map<Pet>(petDto);
            await _repositoryManager.Pets.CreatePetAsync(pet);
            pet.BirthDate = now;
            pet.HungerValue = HungerLevels.FullMinHungerValue;
            pet.ThirstValue = ThirstLevels.FullMinThirstValue;
            pet.IsAlive = true;
            pet.HappinessDaysCount = 0;
            pet.DeathDate = CalculateDeathDate(pet.HungerValue, pet.ThirstValue, now);
            pet.LastPetDetailsUpdatingTime = now;
            await _repositoryManager.SaveChangeAsync();
            var feedingEvent = new FeedingEventCreatingDto { PetId = pet.Id };
            await _feedingEventsService.CreateFeedingEventAsync(feedingEvent);
            var thirstQuenchingEvent = new ThirstQuenchingEventCreatingDto { PetId = pet.Id };
            await _thirstQuenchingEventsService.CreateThirstQuenchingEventAsync(thirstQuenchingEvent);
            return pet.Id;
        }

        public async Task DeletePetByIdAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            _repositoryManager.Pets.DeletePet(pet);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task FeedPetAsync(Guid petId, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            var friendFarms = await _repositoryManager.Farms.GetFriendFarmsAsync(userId);
            if (!friendFarms.Where(e => e.Pets.Where(p => p.Id.Equals(petId)).Any()).Any() && farm.UserId != userId)
                throw new InvalidOperationException("you can't feed this pet");

            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            await UpdatePetVitalSignsAsync(pet, now);
            if (!pet.IsAlive)
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.HungerValue >= HungerLevels.FullMinHungerValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _feedingEventsService.CreateFeedingEventAsync(new FeedingEventCreatingDto { PetId = pet.Id });
            pet.HungerValue += PetSettings.FeedingUnit;
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task QuenchPetThirstAsync(Guid petId, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            var friendFarms = await _repositoryManager.Farms.GetFriendFarmsAsync(userId);
            if (!friendFarms.Where(e => e.Pets.Where(p => p.Id.Equals(petId)).Any()).Any() && farm.UserId != userId)
                throw new InvalidOperationException("you can't feed this pet");

            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            await UpdatePetVitalSignsAsync(pet, now);
            if (!pet.IsAlive) 
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.ThirstValue >= ThirstLevels.FullMinThirstValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _thirstQuenchingEventsService.CreateThirstQuenchingEventAsync(new ThirstQuenchingEventCreatingDto { PetId = pet.Id });
            pet.ThirstValue += PetSettings.ThirstQuenchingUnit;
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<PetReadingDto> GetPetByIdAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            await UpdatePetVitalSignsAsync(pet, now);
            var petDto = _mapper.Map<PetReadingDto>(pet);
            return petDto;
        }

        public async Task<IEnumerable<PetMinReadingDto>> GetPetsAsync()
        {
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            var pets = await _repositoryManager.Pets.GetPetsAsync(now);
            foreach (var pet in pets)
                await UpdatePetVitalSignsAsync(pet, now);
            var petsDto = _mapper.Map<IEnumerable<PetMinReadingDto>>(pets);
            return petsDto;
        }

        public async Task<IEnumerable<PetReadingDto>> GetUserPetsAsync(Guid userId)
        {
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            var pets = await _repositoryManager.Pets.GetUserPetsAsync(userId, now);
            foreach (var pet in pets)
                await UpdatePetVitalSignsAsync(pet, now);
            var petsDto = _mapper.Map<IEnumerable<PetReadingDto>>(pets);
            return petsDto;
        }

        public async Task UpdatePetAsync(PetUpdatingDto petDto, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petDto.petId, false);
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(pet.FarmId, false);
            if (farm.UserId != userId)
                throw new InvalidOperationException("you can't update this pet");

            var petForUpdating = _mapper.Map<Pet>(petDto);
            pet.Id = petDto.petId;
            _repositoryManager.Pets.UpdatePet(petForUpdating);
            await _repositoryManager.SaveChangeAsync();
        }




        public async Task UpdatePetVitalSignsAsync(Pet pet, long updationTime) {
            var hungerValue = CalculateHungerValueAtTime(pet.HungerValue, pet.LastPetDetailsUpdatingTime, updationTime);
            var thirstValue = CalculateThirstValueAtTime(pet.ThirstValue, pet.LastPetDetailsUpdatingTime, updationTime);
            pet.HungerValue = hungerValue;
            pet.ThirstValue = thirstValue;
            pet.LastPetDetailsUpdatingTime = updationTime;
            if (hungerValue >= HungerLevels.NormalMinHungerValue && thirstValue >= ThirstLevels.NormalMinThirstValue)
            {
                pet.HappinessDaysCount = GetPetHappinessDaysCountAtTime(pet.HappinessDaysCount, pet.LastPetDetailsUpdatingTime, updationTime);
                return;
            }
            if (!IsPetAlive(hungerValue, thirstValue)) await MakePetDeadAsync(pet, hungerValue, thirstValue, updationTime);
        }

        public float CalculateHungerValueAtTime(float hungerValue, long lastPetDetailsUpdatingTime, long time)
        {
            var lastFeedingTimeSpan = _dateTimeConverter.GetHours(time - lastPetDetailsUpdatingTime); // in pet's time
            hungerValue -= lastFeedingTimeSpan * PetSettings.HungerUnitsPerPetsHour; //TODO: keep it in mind, that you don't know, what TotalHours is. Ticks into seconds

            return hungerValue;
        }

        public float CalculateThirstValueAtTime(float thirstValue, long lastPetDetailsUpdatingTime, long time)
        {
            var lastThirstQuenchingTimeSpan = _dateTimeConverter.GetHours(time - lastPetDetailsUpdatingTime); // in pet's time
            thirstValue -= lastThirstQuenchingTimeSpan * PetSettings.ThirstUnitsPerPetsHour; //TODO: keep it in mind, that you don't know, what TotalHours is. Ticks into seconds
            return thirstValue;
        }

        public int GetPetHappinessDaysCountAtTime(int happinessDaysCount, long lastPetDetailsUpdatingTime, long time)
        {
            var newPetDetailsUpdatingTime = _dateTimeConverter.GetDays(lastPetDetailsUpdatingTime);
            var today = _dateTimeConverter.GetDays(time);
            var happinessDays = happinessDaysCount + _dateTimeConverter.SubtractDays(newPetDetailsUpdatingTime, today);
            return happinessDays;
        }

        public long CalculateDeathDate(float updatedHungerValue, float updatedThirstValue, long time)
        {
            long timeSpanByHungerValue = (long)((updatedHungerValue - HungerLevels.HungerMinHungerValue) / PetSettings.HungerUnitsPerPetsHour * 3600);
            long timeSpanByThirstValue = (long)((updatedThirstValue - ThirstLevels.ThirstyMinThirstValue) / PetSettings.ThirstUnitsPerPetsHour * 3600);
            return time + (timeSpanByHungerValue > timeSpanByThirstValue ? timeSpanByThirstValue : timeSpanByHungerValue);
        }

        public bool IsPetAlive(float hungerValue, float thirstValue)
        { 
            if (hungerValue >= HungerLevels.HungerMinHungerValue && thirstValue >= ThirstLevels.ThirstyMinThirstValue) return true;
            return false;
        }

        public async Task MakePetDeadAsync(Pet pet, float updatedHungerValue, float updatedThirstValue, long now)
        {
            if (IsPetAlive(updatedHungerValue, updatedThirstValue))
                throw new InvalidOperationException("can't kill the pet");
            pet.DeathDate = CalculateDeathDate(updatedHungerValue, updatedThirstValue, now);
            pet.IsAlive = false;
            _repositoryManager.Pets.UpdatePet(pet);
            await _repositoryManager.SaveChangeAsync();
        }
    }
}
