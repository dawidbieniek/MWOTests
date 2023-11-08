using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class OrderRepository(IAppDbContext appDbContext) : BaseRepository<Order, int>(appDbContext), IOrderRepository
{
}