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
                .ForMember(dest => dest.TrainingTestTitle, opts => opts.MapFrom(item => "CSS Test"))
                .ForMember(dest => dest.TrainingTestTotal, opts => opts.MapFrom(item => 20));
            CreateMap<UserAchievementDTO, UserAchievement>();

            CreateMap<UserAchievement, GetUserAchievementDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email))
                .ForMember(dest => dest.TrainingTestTitle, opts => opts.MapFrom(item => "CSS Test"))
                .ForMember(dest => dest.TrainingTestTotal, opts => opts.MapFrom(item => 20));

            CreateMap<SetUserAchievementDTO, UserAchievement>();
        }
    }
}
