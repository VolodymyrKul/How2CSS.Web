using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.SpecializedDTOs
{
    public class GetUserAchievementDTO
    {
        public string Title { get; set; }
        public string Notes { get; set; }
        public string LevelTitle { get; set; }
        public int LevelTotal { get; set; }
        public string UserEmail { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
