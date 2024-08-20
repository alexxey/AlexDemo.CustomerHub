using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts;
using AlexDemo.CustomerHub.Core.Entities;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.DataAccess.EF.Repositories
{
    public abstract class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : BaseEntity
    {
        protected readonly CustomerHubDbContext DbContext;

        protected GenericRepository(CustomerHubDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T?> GetById(TId id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }
        
        public async Task<bool> CheckExistAndValid(TId id)
        {
            var entity = await GetById(id);
            return entity != null && entity.Status != Status.Deleted;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;

            await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// this is a physical delete operation : only use it if you understand the logic behind
        /// for logical delete please use DeleteById method
        /// </summary>
        /// <param name="entity">entity to physically remove from data layer</param>
        /// <returns></returns>
        public async Task Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteById(TId id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete == null || entityToDelete?.Status == Status.Deleted)
            {
                return;
            }

            entityToDelete.Status = Status.Deleted;
            DbContext.Entry(entityToDelete).State = EntityState.Modified;

            await DbContext.SaveChangesAsync();
        }
    }
}
