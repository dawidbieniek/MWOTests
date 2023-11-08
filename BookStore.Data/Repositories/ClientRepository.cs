using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class ClientRepository(IAppDbContext appDbContext) : BaseRepository<Client, int>(appDbContext), IClientRepository
{
}