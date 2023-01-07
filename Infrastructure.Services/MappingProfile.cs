using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using AutoMapper;
using Domain.Core.Models;
using Infrastructure.Data;
using Infrastructure.Services.Helpers;
using System;
using System.Linq;

namespace Infrastructure.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IPetStatsCalculatingService petStatsCalculatingService, IFarmStatsCalculatingService farmStatsCalculatingService, IDateTimeConverter dateTimeConverter, IDateTimeProvider dateTimeProvider)
        {
            CreateMap<UserCreatingDto, User>();
            CreateMap<UserCreatingDto, UserInfo>();
            CreateMap<UserInfo, UserMinReadingDto>();
            CreateMap<UserInfo, UserReadingDto>()
                .ForMember(e => e.Email, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<UserUpdatingDto, UserInfo>();

            CreateMap<FarmCreatingDto, Farm>();
            CreateMap<Farm, FarmReadingDto>()
                .ForMember(e => e.FarmFriends, opt => opt.MapFrom(src => src.FarmFriends))
                .ForMember(e => e.Pets, opt => opt.MapFrom(src => src.Pets))
                .ForMember(e => e.UserInfo, opt => opt.MapFrom(src => src.UserInfo))
                .AfterMap((src, dst) => dst = farmStatsCalculatingService.UpdateFarmStatsAsync(dst, dateTimeConverter.ConvertToPetsTime(dateTimeProvider.Now)).Result);
            CreateMap<Farm, FarmMinReadingDto>()
                .ForMember(e => e.UserInfo, opt => opt.MapFrom(src => src.UserInfo))
                .AfterMap((src, dst) => dst = farmStatsCalculatingService.UpdateMinFarmStatsAsync(dst, dateTimeConverter.ConvertToPetsTime(dateTimeProvider.Now)).Result);
            CreateMap<FarmUpdatingDto, Farm>();

            CreateMap<PetCreatingDto, Pet>();
            CreateMap<Pet, PetReadingDto>()
                .BeforeMap((src, dst) => src = petStatsCalculatingService.UpdatePetVitalSigns(src, dateTimeConverter.ConvertToPetsTime(dateTimeProvider.Now)))
                .ForMember(e => e.HungerLevel, opt => opt.MapFrom(src => HungerLevels.GetHungerLevelName(src.HungerValue)))
                .ForMember(e => e.ThirstLevel, opt => opt.MapFrom(src => ThirstLevels.GetThirstLevelName(src.ThirstValue)))
                .ForMember(e => e.Age, opt => opt.MapFrom(src => petStatsCalculatingService.CalculatePetAge(src, dateTimeConverter.ConvertToPetsTime(dateTimeProvider.Now))))
                .ForMember(e => e.BodyPicName, opt => opt.MapFrom(src => src.Body.PictureName))
                .ForMember(e => e.EyesPicName, opt => opt.MapFrom(src => src.Eyes.PictureName))
                .ForMember(e => e.MouthPicName, opt => opt.MapFrom(src => src.Mouth.PictureName))
                .ForMember(e => e.NosePicName, opt => opt.MapFrom(src => src.Nose.PictureName))
                .ForMember(e => e.Friends, opt => opt.MapFrom(src => src.Farm.FarmFriends.Select(e => e.UserId)))
                .ForMember(e => e.UserId, opt => opt.MapFrom(src => src.Farm.UserId))
                .ForMember(e => e.HungerInProcents, opt => opt.MapFrom(src => petStatsCalculatingService.GetHungerInPercents(src.HungerValue)))
                .ForMember(e => e.ThirstInProcents, opt => opt.MapFrom(src => petStatsCalculatingService.GetThirstInPercents(src.ThirstValue)))
                .ForMember(e => e.HungerInProcentsPerRealHour, opt => opt.MapFrom(src => petStatsCalculatingService.GetHungerInPercentsPerRealHour()))
                .ForMember(e => e.ThirstInProcentsPerRealHour, opt => opt.MapFrom(src => petStatsCalculatingService.GetThirstInPercentsPerRealHour()));
            CreateMap<Pet, PetMinReadingDto>()
                .BeforeMap((src, dst) => src = petStatsCalculatingService.UpdatePetVitalSigns(src, dateTimeConverter.ConvertToPetsTime(dateTimeProvider.Now)))
                .ForMember(e => e.HungerLevel, opt => opt.MapFrom(src => HungerLevels.GetHungerLevelName(src.HungerValue)))
                .ForMember(e => e.ThirstLevel, opt => opt.MapFrom(src => ThirstLevels.GetThirstLevelName(src.ThirstValue)))
                .ForMember(e => e.Age, opt => opt.MapFrom(src => petStatsCalculatingService.CalculatePetAge(src, dateTimeConverter.ConvertToPetsTime(dateTimeProvider.Now))));
            CreateMap<PetUpdatingDto, Pet>();

            CreateMap<FarmFriendCreatingDto, FarmFriend>();
            CreateMap<FarmFriend, PetReadingDto>();

            CreateMap<FeedingEventCreatingDto, FeedingEvent>();

            CreateMap<ThirstQuenchingEventCreatingDto, ThirstQuenchingEvent>();

            CreateMap<FarmFriend, FarmFriendReadingDto>()
                .ForMember(e => e.FirstName, opt => opt.MapFrom(src => src.UserInfo.FirstName))
                .ForMember(e => e.LastName, opt => opt.MapFrom(src => src.UserInfo.LastName))
                .ForMember(e => e.PictureSrc, opt => opt.MapFrom(src => src.UserInfo.PictureSrc));
        }
    }
}
