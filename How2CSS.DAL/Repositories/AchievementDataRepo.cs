using How2CSS.Core.Abstractions.IRepositories;
using How2CSS.Core.Models;
using How2CSS.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.DAL.Repositories
{
    public class AchievementDataRepo : BaseRepo<AchievementData>, IAchievementDataRepo
    {
        private readonly How2CSSDbContext _context;
        public AchievementDataRepo(How2CSSDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<AchievementData>> GetAllAsync()
        {
            return await _context.Set<AchievementData>()
                .Include(achievementData => achievementData.IdUserAchievementNavigation)
                .ToListAsync();
        }

        public override async Task<AchievementData> GetByIdAsync(int id)
        {
            return await _context.Set<AchievementData>()
                .Where(e => e.Id == id)
                .Include(achievementData => achievementData.IdUserAchievementNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
