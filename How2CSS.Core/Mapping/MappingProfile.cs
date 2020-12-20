using AutoMapper;
using How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<SignUpDTO, User>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(item => "User"));

            CreateMap<SignInDTO, User>();

            CreateMap<UserAchievement, UserAchievementDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email))
                .ForMember(dest => dest.LevelTitle, opts => opts.MapFrom(item => item.IdLevelNavigation.Title))
                .ForMember(dest => dest.LevelTotal, opts => opts.MapFrom(item => item.IdLevelNavigation.TasksCount));
            CreateMap<UserAchievementDTO, UserAchievement>();

            CreateMap<UserAchievement, GetUserAchievementDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email))
                .ForMember(dest => dest.LevelTitle, opts => opts.MapFrom(item => item.IdLevelNavigation.Title))
                .ForMember(dest => dest.LevelTotal, opts => opts.MapFrom(item => item.IdLevelNavigation.TasksCount));

            CreateMap<SetUserAchievementDTO, UserAchievement>();

            CreateMap<AchievementData, AchievementDataDTO>();
            CreateMap<AchievementDataDTO, AchievementData>();

            CreateMap<Level, LevelDTO>();
            CreateMap<LevelDTO, Level>();
        }
    }
}
