using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class UserAchievement : IBaseEntity
    {
        public UserAchievement()
        {
            AchievementDatas = new HashSet<AchievementData>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int IdLevel { get; set; }
        public int IdUser { get; set; }
        public DateTime SaveDate { get; set; }


        public virtual User IdUserNavigation { get; set; }
        public virtual Level IdLevelNavigation { get; set; }
        public virtual ICollection<AchievementData> AchievementDatas { get; set; }
    }
}
