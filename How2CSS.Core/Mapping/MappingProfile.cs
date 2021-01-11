using AutoMapper;
using How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
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

            CreateMap<SetUserAchievementDTO, AchievementData>();

            CreateMap<AchievementData, AchievementDataDTO>();
            CreateMap<AchievementDataDTO, AchievementData>();

            CreateMap<Level, LevelDTO>();
            CreateMap<LevelDTO, Level>();

            CreateMap<Level, LevelTasksDTO>();

            CreateMap<AchievementData, SimpleAchievDataDTO>()
                .ForMember(dest => dest.CompletedCount, opts => opts.MapFrom(item => item.CompletedCount.ToString() + "/" + item.IdUserAchievementNavigation.IdLevelNavigation.TasksCount.ToString()))
                .ForMember(dest => dest.CorrectCount, opts => opts.MapFrom(item => item.CorrectCount.ToString() + "/" + item.IdUserAchievementNavigation.IdLevelNavigation.TasksCount.ToString()))
                .ForMember(dest => dest.SaveDate, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.SaveDate))
                .ForMember(dest => dest.TrainingTestTitle, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.IdLevelNavigation.Title));

            CreateMap<AchievementData, DetailAchievDataDTO>()
                .ForMember(dest => dest.CompletedCount, opts => opts.MapFrom(item => item.CompletedCount.ToString() + "/" + item.IdUserAchievementNavigation.IdLevelNavigation.TasksCount.ToString()))
                .ForMember(dest => dest.CorrectCount, opts => opts.MapFrom(item => item.CorrectCount.ToString() + "/" + item.IdUserAchievementNavigation.IdLevelNavigation.TasksCount.ToString()))
                .ForMember(dest => dest.SaveDate, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.SaveDate))
                .ForMember(dest => dest.TrainingTestTitle, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.IdLevelNavigation.Title))
                .ForMember(dest => dest.AchievTitle, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.Title))
                .ForMember(dest => dest.AchievNotes, opts => opts.MapFrom(item => item.IdUserAchievementNavigation.Notes));

            CreateMap<Answer, AnswerDTO>().ReverseMap();

            CreateMap<CSSTask, CSSTaskDTO>().ReverseMap();
            CreateMap<CSSTask, CSSTaskDTOOutput>()
                .ForMember(dest => dest.QuestionText, opts => opts.MapFrom(src => src.IdQuestionNavigation.QuestionText))
                .ForMember(dest => dest.EtalonAnswer, opts => opts.MapFrom(src => src.IdAnswerNavigation.EtalonAnswer));
            CreateMap<CSSTask, CSSTaskDetailedDTO>()
                .ForMember(dest => dest.Answer, opts => opts.MapFrom(item => item.IdAnswerNavigation.EtalonAnswer))
                .ForMember(dest => dest.Question, opts => opts.MapFrom(item => item.IdQuestionNavigation.QuestionText));


            CreateMap<Hint, HintDTO>().ReverseMap();
            CreateMap<Metadata, MetadataDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<TagDistribution, TagDistributionDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<TaskDistribution, TaskDistributionDTO>().ReverseMap();

            CreateMap<TaskDistribution, TaskDistributionDetailedDTO>()
                .ForMember(dest => dest.Task, opts => opts.MapFrom(item => item.IdTaskNavigation));

            CreateMap<TaskResult, TaskResultDTO>().ReverseMap();
            CreateMap<UnitDistribution, UnitDistributionDTO>().ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
        }
    }
}
