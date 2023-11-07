using BookStore.Data.Entities;

namespace BookStore.Data.Interfaces;

internal interface IOrderRepository : IBaseRepository<Order, int>
{
}