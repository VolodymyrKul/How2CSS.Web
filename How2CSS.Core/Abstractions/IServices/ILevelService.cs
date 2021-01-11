using How2CSS.Core.Abstractions.IServices.Base;
using How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs;
using How2CSS.Core.Enums;
using How2CSS.Core.Models;
using How2CSS.Core.DTO.AnotherDTOs.SpecializedDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions.IServices
{
    public interface ILevelService : IBaseService<LevelDTO, LevelDTO>
    {
        Task GenerateAsync(Difficulty difficulty);
        Task<List<LevelTasksDTO>> GetAllDetailed();
    }
}
