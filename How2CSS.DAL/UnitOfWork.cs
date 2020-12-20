using How2CSS.Core.Abstractions;
using How2CSS.Core.Abstractions.IRepositories;
using How2CSS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepo _userRepo;
        private IUserAchievementRepo _userAchievementRepo;
        private IAchievementDataRepo _achievementDataRepo;
        private ILevelRepo _levelRepo;
        private How2CSSDbContext _context;

        public UnitOfWork(How2CSSDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public IUserRepo UserRepo 
        {
            get { return _userRepo ??= new UserRepo(_context); }
        }

        public IUserAchievementRepo UserAchievementRepo
        {
            get { return _userAchievementRepo ??= new UserAchievementRepo(_context); }
        }

        public IAchievementDataRepo AchievementDataRepo
        {
            get { return _achievementDataRepo ??= new AchievementDataRepo(_context); }
        }

        public ILevelRepo LevelRepo
        {
            get { return _levelRepo ??= new LevelRepo(_context); }
        }
    }
}
