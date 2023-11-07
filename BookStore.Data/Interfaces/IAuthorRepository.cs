using BookStore.Data.Entities;

namespace BookStore.Data.Interfaces;

internal interface IAuthorRepository : IBaseRepository<Author, int>
{
}