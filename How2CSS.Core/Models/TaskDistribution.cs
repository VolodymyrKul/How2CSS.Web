using How2CSS.Core.Enums;
using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class TaskDistribution : IBaseEntity
    {
        public int Id { get; set; }
        public int TaskOrder { get; set; }
        public int IdTask { get; set; }
        public int IdLevel { get; set; }
        public virtual CSSTask IdTaskNavigation { get; set; }
        public virtual Level IdLevelNavigation { get; set; }
    }
}
