using How2CSS.Core.Abstractions.IRepositories;
using How2CSS.Core.Models;
using How2CSS.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.DAL.Repositories
{
    public class UnitRepo : BaseRepo<Unit>, IUnitRepo
    {
        private readonly How2CSSDbContext _context;
        public UnitRepo(How2CSSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
