using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Beispiel.Anwendung.Interfaces;

public interface IDbContext
{
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        IQueryable<TEntity> SetQueryable<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
}