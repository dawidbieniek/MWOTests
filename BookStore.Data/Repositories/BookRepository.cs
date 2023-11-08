using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class BookRepository(IAppDbContext appDbContext) : BaseRepository<Book, int>(appDbContext), IBookRepository
{
}