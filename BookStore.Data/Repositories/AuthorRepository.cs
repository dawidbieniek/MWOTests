using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class AuthorRepository(IAppDbContext appDbContext) : BaseRepository<Author, int>(appDbContext), IAuthorRepository
{
}