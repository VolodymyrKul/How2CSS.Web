using How2CSS.Core.Abstractions.IRepositories.Base;
using How2CSS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions.IRepositories
{
    public interface ICSSTaskRepo : IBaseRepo<CSSTask>
    {
        Task<IEnumerable<CSSTask>> GetAllDetailedAsync();
    }
}
