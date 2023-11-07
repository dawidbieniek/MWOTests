using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
{
	public OrderRepository(IAppDbContext appDbContext) : base(appDbContext)
	{
	}
}