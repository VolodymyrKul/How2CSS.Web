using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs
{
    public class SetUserAchievementDTO
    {
        public string Title { get; set; }
        public string Notes { get; set; }
        public int IdLevel { get; set; }
        public int IdUser { get; set; }
        public int CompletedCount { get; set; }
        public int CorrectCount { get; set; }
        public int CurrentMark { get; set; }
    }
}
