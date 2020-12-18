using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class User : IBaseEntity
    {
        public User()
        {
            UserAchievements = new HashSet<UserAchievement>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
