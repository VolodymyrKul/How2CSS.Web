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
    public class UserAchievementRepo : BaseRepo<UserAchievement>, IUserAchievementRepo
    {
        private readonly How2CSSDbContext _context;
        public UserAchievementRepo(How2CSSDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<UserAchievement>> GetAllAsync()
        {
            return await _context.Set<UserAchievement>()
                .Include(userAchievement => userAchievement.IdUserNavigation)
                .Include(userAchievement => userAchievement.IdLevelNavigation)
                .ToListAsync();
        }

        public override async Task<UserAchievement> GetByIdAsync(int id)
        {
            return await _context.Set<UserAchievement>()
                .Where(e => e.Id == id)
                .Include(userAchievement => userAchievement.IdUserNavigation)
                .Include(userAchievement => userAchievement.IdLevelNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
