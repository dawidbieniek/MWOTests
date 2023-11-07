﻿namespace BookStore.Data.Interfaces;

public interface IBaseRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
	IAsyncEnumerable<TEntity> GetAllAsync();
	Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken);
	void Add(TEntity entity);
	void Update(TEntity entity);
	void Remove(TEntity entity);
}