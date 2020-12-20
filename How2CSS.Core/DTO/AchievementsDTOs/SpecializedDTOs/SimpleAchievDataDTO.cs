using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs
{
    public class SimpleAchievDataDTO
    {
        public string TrainingTestTitle { get; set; }
        public string CompletedCount { get; set; }
        public string CorrectCount { get; set; }
        public int CurrentMark { get; set; }
        public int TryCount { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
