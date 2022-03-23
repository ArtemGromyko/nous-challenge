using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleaningManagement.DAL.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CleaningManagementDbContext CleaningManagementDbContext;
        public RepositoryBase(CleaningManagementDbContext repositoryContext)
        {
            CleaningManagementDbContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => CleaningManagementDbContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            CleaningManagementDbContext.Set<T>().Where(expression).AsNoTracking();

        public async Task CreateAsync(T entity)
        {
            CleaningManagementDbContext.Set<T>().Add(entity);
            await CleaningManagementDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            CleaningManagementDbContext.Set<T>().Update(entity);
            await CleaningManagementDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            CleaningManagementDbContext.Set<T>().Remove(entity);
            await CleaningManagementDbContext.SaveChangesAsync();
        }
    }
}
