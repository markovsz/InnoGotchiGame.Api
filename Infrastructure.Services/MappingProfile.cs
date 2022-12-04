using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using AutoMapper;
using Domain.Core.Models;
using Infrastructure.Data;
using Infrastructure.Services.Helpers;
using System;

namespace Infrastructure.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IPetStatsCalculatingService petStatsCalculatingService, IDateTimeConverter dateTimeConverter)
        {
            CreateMap<UserCreatingDto, User>();
            CreateMap<UserCreatingDto, UserInfo>();
            CreateMap<UserInfo, UserReadingDto>();
            CreateMap<UserInfoUpdatingDto, UserInfo>();

            CreateMap<FarmCreatingDto, Farm>();
            CreateMap<Farm, FarmReadingDto>()
                .ForMember(e => e.FarmFriends, opt => opt.MapFrom(src => src.FarmFriends))
                .ForMember(e => e.Pets, opt => opt.MapFrom(src => src.Pets));
            CreateMap<Farm, FarmMinReadingDto>();
            CreateMap<FarmUpdatingDto, Farm>();

            CreateMap<PetCreatingDto, Pet>();
            CreateMap<Pet, PetReadingDto>()
                .BeforeMap((src, dst) => src = petStatsCalculatingService.UpdatePetVitalSignsAsync(src, dateTimeConverter.ConvertToPetsTime(DateTime.Now)))
                .ForMember(e => e.HungerLevel, opt => opt.MapFrom(src => HungerLevels.GetHungerLevelName(src.HungerValue)))
                .ForMember(e => e.ThirstLevel, opt => opt.MapFrom(src => ThirstLevels.GetThirstLevelName(src.ThirstValue)))
                .ForMember(e => e.Age, opt => opt.MapFrom(src => dateTimeConverter.GetYears(dateTimeConverter.ConvertToPetsTime(DateTime.Now) - src.BirthDate)));
            CreateMap<Pet, PetMinReadingDto>()
                .BeforeMap((src, dst) => src = petStatsCalculatingService.UpdatePetVitalSignsAsync(src, dateTimeConverter.ConvertToPetsTime(DateTime.Now)))
                .ForMember(e => e.HungerLevel, opt => opt.MapFrom(src => HungerLevels.GetHungerLevelName(src.HungerValue)))
                .ForMember(e => e.ThirstLevel, opt => opt.MapFrom(src => ThirstLevels.GetThirstLevelName(src.ThirstValue)))
                .ForMember(e => e.Age, opt => opt.MapFrom(src => dateTimeConverter.GetYears(dateTimeConverter.ConvertToPetsTime(DateTime.Now) - src.BirthDate)));
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
