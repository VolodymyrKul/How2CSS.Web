﻿using How2CSS.Core.Abstractions.IServices.Base;
using How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions.IServices
{
    public interface IAchievementDataService : IBaseService<AchievementDataDTO, AchievementDataDTO>
    {
        Task<List<CompareAchievDataDTO>> GetCompareAchievs(string OwnUserEmail, string AnotherUserEmail);
        Task<List<SimpleAchievDataDTO>> GetAchievsByEmail(string UserEmail);
        Task<List<DetailAchievDataDTO>> GetDetailAchievsByEmail(string UserEmail);
        Task<bool> SaveAchievement(UpdateUserAchievement updateUserAchievementDTO);
    }
}
