using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs
{
    public class AchievementDataDTO
    {
        public int Id { get; set; }
        public int CompletedCount { get; set; }
        public int CurrentCount { get; set; }
        public int CurrentMark { get; set; }
        public int TryCount { get; set; }
        public int IdUserAchievement { get; set; }
    }
}
