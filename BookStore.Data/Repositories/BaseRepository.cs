using BookStore.Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories;

public abstract class BaseRepository<TEntity, TKey>(IAppDbContext appDbContext) : IBaseRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
	protected readonly IAppDbContext AppDbContext = appDbContext;

	public IAsyncEnumerable<TEntity> GetAllAsync()
	{
		return AppDbContext.Set<TEntity, TKey>().AsAsyncEnumerable();
	}

	public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken)
	{
		return await Task.Run(() => AppDbContext.Set<TEntity, TKey>().AsNoTracking().FirstOrDefault(d => d.Id!.Equals(id))!);
	}

	public void Add(TEntity entity)
	{
		AppDbContext.Set<TEntity, TKey>().Add(entity);
		AppDbContext.SaveChanges();
	}

	public void Update(TEntity entity)
	{
		AppDbContext.Set<TEntity, TKey>().Update(entity);
		AppDbContext.SaveChanges();
	}

	public void Remove(TEntity entity)
	{
		AppDbContext.Set<TEntity, TKey>().Remove(entity);
		AppDbContext.SaveChanges();
	}
}