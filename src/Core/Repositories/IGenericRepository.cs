using Core.BaseModels.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseEntity, new()
    {
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);
    }
}
