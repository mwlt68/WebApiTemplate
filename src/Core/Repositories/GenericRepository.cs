using Core.BaseModels.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity, new() where TContext : DbContext, new()
    {
        public readonly TContext context;
        public GenericRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await context.Set<TEntity>().FindAsync(id);
            context.Set<TEntity>().Remove(deleteEntity);
            var data = await context.SaveChangesAsync();
            if (data > 0)
                return true;
            return false;
        }
    }
}
