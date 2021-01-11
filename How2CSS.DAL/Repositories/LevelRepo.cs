using How2CSS.Core.Abstractions.IRepositories;
using How2CSS.Core.Models;
using How2CSS.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.DAL.Repositories
{
    public class LevelRepo : BaseRepo<Level>, ILevelRepo
    {
        private readonly How2CSSDbContext _context;
        public LevelRepo(How2CSSDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<Level>> GetAllDetailedAsync()
        {
            return await _context.Set<Level>()
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.IdAnswerNavigation)
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.IdQuestionNavigation)
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.IdMetadataNavigation)
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.TaskResults)
                .ToListAsync();
        }
    }
}
