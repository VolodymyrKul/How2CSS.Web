using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class Metadata : IBaseEntity
    {
        public Metadata()
        {
            TagDistributions = new HashSet<TagDistribution>();
            Tasks = new HashSet<CSSTask>();
        }
        public int Id { get; set; }
        public int IdUnit { get; set; }
        public virtual Unit IdUnitNavigation { get; set; }
        public virtual ICollection<TagDistribution> TagDistributions { get; set; }
        public virtual ICollection<CSSTask> Tasks { get; set; }
    }
}
