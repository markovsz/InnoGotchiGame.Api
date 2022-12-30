using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.RequestParameters;
using Infrastructure.Data;
using Infrastructure.Services.Exceptions;
using Infrastructure.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class PetsService : IPetsService
    {
        private IFeedingEventsService _feedingEventsService;
        private IThirstQuenchingEventsService _thirstQuenchingEventsService;
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private IDateTimeConverter _dateTimeConverter;
        private IPetStatsCalculatingService _petStatsCalculatingService;

        public PetsService(IFeedingEventsService feedingEventsService, IThirstQuenchingEventsService thirstQuenchingEventsService, IRepositoryManager repositoryManager, IMapper mapper, IPetStatsCalculatingService petStatsCalculatingService, IDateTimeConverter dateTimeConverter)
        {
            _feedingEventsService = feedingEventsService;
            _thirstQuenchingEventsService = thirstQuenchingEventsService;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _petStatsCalculatingService = petStatsCalculatingService;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<Guid> CreatePetAsync(PetCreatingDto petDto, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(petDto.FarmId, false);
            if (farm is null)
                throw new EntityNotFoundException("invalid farm id");
            if (farm.UserId != userId)
                throw new AccessException("you don't have permissions");

            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);

            var pet = _mapper.Map<PetCreatingDto, Pet>(petDto);
            await _repositoryManager.Pets.CreatePetAsync(pet);
            pet.BirthDate = now;
            pet.HungerValue = HungerLevels.FullMinHungerValue;
            pet.ThirstValue = ThirstLevels.FullMinThirstValue;
            pet.IsAlive = true;
            pet.HappinessDaysCount = 0;
            pet.DeathDate = _petStatsCalculatingService.CalculateDeathDate(pet.HungerValue, pet.ThirstValue, now);
            pet.LastPetDetailsUpdatingTime = now;

            var petBody = await _repositoryManager.PetBodies.GetPetBodyByNameAsync(petDto.BodyPicName);
            if (petBody is null)
                throw new IncorrectRequestDataException("invalid pet's body pic name");
            pet.BodyId = petBody.Id;
            pet.BodyPictureX = petDto.BodyPictureX;
            pet.BodyPictureY = petDto.BodyPictureY;
            pet.BodyPictureScale = petDto.BodyPictureScale;

            var petEyes = await _repositoryManager.PetEyes.GetPetEyesByNameAsync(petDto.EyesPicName);
            if (petEyes is null)
                throw new IncorrectRequestDataException("invalid pet's eyes pic name");
            pet.EyesId = petEyes.Id;
            pet.EyesPictureX = petDto.EyesPictureX;
            pet.EyesPictureY = petDto.EyesPictureY;
            pet.EyesPictureScale = petDto.EyesPictureScale;

            var petMouth = await _repositoryManager.PetMouths.GetPetMouthByNameAsync(petDto.MouthPicName);
            if (petMouth is null)
                throw new IncorrectRequestDataException("invalid pet's mouth pic name");
            pet.MouthId = petMouth.Id;
            pet.MouthPictureX = petDto.MouthPictureX;
            pet.MouthPictureY = petDto.MouthPictureY;
            pet.MouthPictureScale = petDto.MouthPictureScale;

            var petNose = await _repositoryManager.PetNoses.GetPetNoseByNameAsync(petDto.NosePicName);
            if (petNose is null)
                throw new IncorrectRequestDataException("invalid pet's nose pic name");
            pet.NoseId = petNose.Id;
            pet.NosePictureX = petDto.NosePictureX;
            pet.NosePictureY = petDto.NosePictureY;
            pet.NosePictureScale = petDto.NosePictureScale;


            await _repositoryManager.SaveChangeAsync();
            var feedingEvent = new FeedingEventCreatingDto { PetId = pet.Id };
            await _feedingEventsService.CreateFeedingEventAsync(feedingEvent);
            var thirstQuenchingEvent = new ThirstQuenchingEventCreatingDto { PetId = pet.Id };
            await _thirstQuenchingEventsService.CreateThirstQuenchingEventAsync(thirstQuenchingEvent);
            return pet.Id;
        }

        public async Task DeletePetByIdAsync(Guid petId, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            if (pet is null)
                throw new EntityNotFoundException("pet with such id doesn't exist");
            var isMinePet = await IsPetOfUsersFarmAsync(pet, userId);
            if (!isMinePet)
                throw new AccessException("you can't feed this pet");
            _repositoryManager.Pets.DeletePet(pet);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<string> FeedPetAsync(Guid petId, Guid userId)
        {

            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);
            bool isAlive = pet.IsAlive;
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            pet = _petStatsCalculatingService.UpdatePetVitalSigns(pet, now);
            bool isFriendsPet = await IsPetOfFriendsFarmAsync(pet, userId);
            bool isMinePet = await IsPetOfUsersFarmAsync(pet, userId);
            if (!isFriendsPet && !isMinePet)
                throw new AccessException("you can't feed this pet");

            if (!isAlive)
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.HungerValue >= HungerLevels.FullMinHungerValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _feedingEventsService.CreateFeedingEventAsync(new FeedingEventCreatingDto { PetId = pet.Id });
            if(pet.IsAlive) pet.HungerValue += PetSettings.FeedingUnit;
            await _repositoryManager.SaveChangeAsync();
            return HungerLevels.GetHungerLevelName(pet.HungerValue);
        }

        public async Task<string> QuenchPetThirstAsync(Guid petId, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);
            bool isAlive = pet.IsAlive;
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            pet = _petStatsCalculatingService.UpdatePetVitalSigns(pet, now);
            bool isFriendsPet = await IsPetOfFriendsFarmAsync(pet, userId);
            bool isMinePet = await IsPetOfUsersFarmAsync(pet, userId);
            if (!isFriendsPet && !isMinePet)
                throw new AccessException("you can't feed this pet");

            if (!isAlive) 
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.ThirstValue >= ThirstLevels.FullMinThirstValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _thirstQuenchingEventsService.CreateThirstQuenchingEventAsync(new ThirstQuenchingEventCreatingDto { PetId = pet.Id });
            if (pet.IsAlive) pet.ThirstValue += PetSettings.ThirstQuenchingUnit;
            await _repositoryManager.SaveChangeAsync();
            return ThirstLevels.GetThirstLevelName(pet.ThirstValue);
        }

        public async Task<PetReadingDto> GetPetByIdAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            if (pet is null)
                throw new EntityNotFoundException("pet was't found");
            var petDto = _mapper.Map<PetReadingDto>(pet);
            return petDto;
        }

        public async Task<PetsPaginationDto> GetPetsAsync(PetParameters parameters)
        {
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            var pets = await _repositoryManager.Pets.GetPetsAsync(parameters, now);
            var petsCount = await _repositoryManager.Pets.GetPetsCountAsync(now);

            var paginationDto = new PetsPaginationDto();
            paginationDto.Pets = _mapper.Map<IEnumerable<PetMinReadingDto>>(pets);
            paginationDto.PagesCount = petsCount;
            return paginationDto;
        }

        public async Task<IEnumerable<PetReadingDto>> GetUserPetsAsync(Guid userId)
        {
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            var pets = await _repositoryManager.Pets.GetUserPetsAsync(userId, now);
            var petsDto = _mapper.Map<IEnumerable<PetReadingDto>>(pets);
            return petsDto;
        }

        public async Task UpdatePetAsync(PetUpdatingDto petDto, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petDto.petId, false);
            if (pet is null)
                throw new EntityNotFoundException("pet was't found");
            var isMinePet = await IsPetOfUsersFarmAsync(pet, userId);
            if (!isMinePet)
                throw new AccessException("you can't update this pet");

            var petForUpdating = _mapper.Map<Pet>(petDto);
            pet.Id = petDto.petId;
            _repositoryManager.Pets.UpdatePet(petForUpdating);
            await _repositoryManager.SaveChangeAsync();
        }

        private async Task<bool> IsPetOfFriendsFarmAsync(Pet pet, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(pet.FarmId, false);
            var friendsFarm = await _repositoryManager.Farms.GetFriendFarmAsync(userId, farm.UserId);
            if (friendsFarm is not null)
                return true;
            return false;
        }

        private async Task<bool> IsPetOfUsersFarmAsync(Pet pet, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(pet.FarmId, false);
            if (farm is not null && farm.UserId == userId)
                return true;
            return false;
        }
    }
}
