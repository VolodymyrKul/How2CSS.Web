using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace How2CSS.Core.Abstractions.IServices.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetIdAsync(int id);
        Task CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
