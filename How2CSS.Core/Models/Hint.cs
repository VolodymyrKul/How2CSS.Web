using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class Hint : IBaseEntity
    {
        public int Id { get; set; }
        public string HintType { get; set; }
        public string HintText { get; set; }
        public int IdTask { get; set; }
        public virtual CSSTask IdTaskNavigation { get; set; }
    }
}
