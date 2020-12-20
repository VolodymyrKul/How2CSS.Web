using How2CSS.Core.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepo UserRepo { get; }
        IUserAchievementRepo UserAchievementRepo { get; }
        IAchievementDataRepo AchievementDataRepo { get; }
        ILevelRepo LevelRepo { get; }
        Task SaveChangesAsync();
    }
}
