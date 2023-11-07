namespace BookStore.Data.Interfaces;

public interface IBaseEntity<TKey>
{
	TKey Id { get; set; }
}
