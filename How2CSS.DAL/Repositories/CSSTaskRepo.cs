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
    public class CSSTaskRepo : BaseRepo<CSSTask>, ICSSTaskRepo
    {
        private readonly How2CSSDbContext _context;
        public CSSTaskRepo(How2CSSDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual async  Task<IEnumerable<CSSTask>> GetAllDetailedAsync()
        {
            return await _context.Set<CSSTask>()
                .Include(t => t.IdAnswerNavigation)
                .Include(t => t.IdQuestionNavigation)
                .Include(t => t.IdMetadataNavigation)
                .Include(t => t.TaskDistributions)
                .Include(t => t.TaskResults)
                .ToListAsync();
        }

        public virtual async Task<CSSTask> GetExecAsync(int id)
        {
            return await _context.Set<CSSTask>()
                .Include(t => t.IdAnswerNavigation)
                .Include(t => t.IdQuestionNavigation)
                .Include(t => t.TaskDistributions)
                    .ThenInclude(td => td.IdLevelNavigation)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
