using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class Unit : IBaseEntity
    {
        public Unit()
        {
            UnitDistributions = new HashSet<UnitDistribution>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UnitDistribution> UnitDistributions { get; set; }
    }
}
