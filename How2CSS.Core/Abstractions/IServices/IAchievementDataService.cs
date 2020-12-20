using How2CSS.Core.Abstractions.IServices.Base;
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
        Task<List<CompareAchievDataDTO>> GetCompareAchievs(int OwnUserId, int AnotherUserId);
        Task<List<SimpleAchievDataDTO>> GetAchievsByEmail(string UserEmail);
        Task<List<DetailAchievDataDTO>> GetDetailAchievsByEmail(string UserEmail);
    }
}
