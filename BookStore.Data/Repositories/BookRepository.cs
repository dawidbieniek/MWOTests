using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class BookRepository : BaseRepository<Book, int>, IBookRepository
{
	public BookRepository(IAppDbContext appDbContext) : base(appDbContext)
	{
	}
}