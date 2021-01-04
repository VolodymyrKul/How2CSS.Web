using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class TaskResult : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime ResultDate { get; set; }
        public long Duration { get; set; }
        public string UserAnswer { get; set; }
        public int Score { get; set; }
        public int IdUser { get; set; }
        public int IdTask { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual CSSTask IdTaskNavigation { get; set; }
    }
}
