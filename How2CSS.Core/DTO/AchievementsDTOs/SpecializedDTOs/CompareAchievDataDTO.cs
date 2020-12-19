using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs
{
    public class CompareAchievDataDTO
    {
        public int CompletedCount { get; set; }
        public int CorrectCount { get; set; }
        public int CurrentMark { get; set; }
        public int IdUserAchievement { get; set; }
    }
}
