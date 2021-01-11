using How2CSS.Core.DTO.AnotherDTOs.StandartDTOs;
using How2CSS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs
{
    public class LevelDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TasksCount { get; set; }
        public Difficulty LevelDifficulty { get; set; }
        public List<CSSTaskDTOOutput> Tasks { get; set; }
    }
}
