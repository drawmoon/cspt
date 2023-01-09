using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SimpleWebApi.DbContexts;
using SimpleWebApi.Repositories.Interfaces;

namespace SimpleWebApi.Repositories
{
	public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        protected ManagementDbContext DbContext;

        public RepositoryBase(ManagementDbContext dbContext)
		{
            DbContext = dbContext;
        }

        public DbSet<TEntity> Entities => DbContext.Set<TEntity>();

        public Task<List<TEntity>> GetAllAsync()
        {
            return Entities.ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync(params string[] includes)
        {
            var query = Entities.AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            var query = Entities.AsQueryable();
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> GetAsync(TKey id, params string[] includes)
        {
            var query = Entities.AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entityEntry = await Entities.AddAsync(entity);
            return entityEntry.Entity;
        }

        public Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            return Entities.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            DbContext.ChangeTracker.TrackGraph(entity, n =>
            {
                n.Entry.State = EntityState.Modified;
            });
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            Entities.Attach(entity);
            Entities.Remove(entity);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return DbContext.Database.BeginTransactionAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
