using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs
{
    public class CompareAchievDataDTO
    {
        public string TrainingTestTitle { get; set; }
        public string OwnCompletedCount { get; set; }
        public string OwnCorrectCount { get; set; }
        public string OwnCurrentMark { get; set; }

        public string AntCompletedCount { get; set; }
        public string AntCorrectCount { get; set; }
        public string AntCurrentMark { get; set; }
    }
}
