namespace BookStore.Data.Interfaces;

public interface IBaseRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
	IEnumerable<TEntity> GetAll();

	TEntity Get(TKey id);

	void Add(TEntity entity);

	void Update(TEntity entity);

	void Remove(TEntity entity);
}