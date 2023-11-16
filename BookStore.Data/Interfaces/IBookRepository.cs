using BookStore.Data.Entities;

namespace BookStore.Data.Interfaces;

public interface IBookRepository : IBaseRepository<Book, int>
{
}