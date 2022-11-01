using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using AutoMapper;
using Domain.Core.Models;
using Infrastructure.Data;
using System.Linq;

namespace Infrastructure.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreatingDto, User>();
            CreateMap<UserCreatingDto, UserInfo>();
            CreateMap<UserInfo, UserReadingDto>();
            CreateMap<UserInfoUpdatingDto, UserInfo>();

            CreateMap<FarmCreatingDto, Farm>();
            CreateMap<Farm, FarmReadingDto>()
                .ForMember(e => e.FarmFriends, opt => opt.MapFrom(src => src.FarmFriends))
                .ForMember(e => e.Pets, opt => opt.MapFrom(src => src.Pets));
            CreateMap<FarmUpdatingDto, Farm>();

            CreateMap<PetCreatingDto, Pet>();
            CreateMap<Pet, PetReadingDto>()
                .ForMember(e => e.HungerLevel, opt => opt.MapFrom(src => HungerLevels.GetHungerLevelName(src.HungerValue)))
                .ForMember(e => e.ThirstLevel, opt => opt.MapFrom(src => ThirstLevels.GetThirstLevelName(src.ThirstValue)));
            CreateMap<PetUpdatingDto, Pet>();

            CreateMap<FarmFriendCreatingDto, FarmFriend>();
            CreateMap<FarmFriend, PetReadingDto>();

            CreateMap<FeedingEventCreatingDto, FeedingEvent>();
            CreateMap<FeedingEvent, FeedingEventReadingDto>();

            CreateMap<ThirstQuenchingEventCreatingDto, ThirstQuenchingEvent>();
            CreateMap<ThirstQuenchingEvent, ThirstQuenchingEventReadingDto>();
        }
    }
}
