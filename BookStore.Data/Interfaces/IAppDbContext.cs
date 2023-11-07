using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Interfaces;

public interface IAppDbContext
{
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);

	int SaveChanges();

	DbSet<TEntity> Set<TEntity, TKey>() where TEntity : class, IBaseEntity<TKey>;
}