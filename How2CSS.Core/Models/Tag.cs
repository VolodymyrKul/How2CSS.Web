using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class Tag : IBaseEntity
    {
        public Tag()
        {
            TagDistributions = new HashSet<TagDistribution>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TagDistribution> TagDistributions { get; set; }
    }
}
