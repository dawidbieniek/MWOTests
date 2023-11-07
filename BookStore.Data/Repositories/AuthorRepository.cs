using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class AuthorRepository : BaseRepository<Author, int>, IAuthorRepository
{
	public AuthorRepository(IAppDbContext appDbContext) : base(appDbContext)
	{
	}
}