using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.DTO.AchievementsDTOs.StandartDTOs
{
    public class UserAchievementDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int IdTrainingTest { get; set; }
        public string TrainingTestTitle { get; set; }
        public int TrainingTestTotal { get; set; }
        public int IdUser { get; set; }
        public string UserEmail { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
