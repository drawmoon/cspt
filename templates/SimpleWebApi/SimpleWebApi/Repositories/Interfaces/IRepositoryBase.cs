using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SimpleWebApi.Repositories.Interfaces
{
	public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
    {
        DbSet<TEntity> Entities { get; }

        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(params string[] includes);

        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetAsync(TKey id, params string[] includes);

        Task<TEntity> InsertAsync(TEntity entity);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TKey id);

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<int> SaveChangesAsync();
    }
}
