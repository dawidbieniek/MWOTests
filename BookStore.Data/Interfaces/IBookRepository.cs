using BookStore.Data.Entities;

namespace BookStore.Data.Interfaces;

internal interface IBookRepository : IBaseRepository<Book, int>
{
}