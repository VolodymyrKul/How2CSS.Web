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
            Metadatas = new HashSet<Metadata>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Metadata> Metadatas { get; set; }
    }
}
