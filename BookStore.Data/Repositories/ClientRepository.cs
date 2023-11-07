using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.Data.Repositories;

public class ClientRepository : BaseRepository<Client, int>, IClientRepository
{
	public ClientRepository(IAppDbContext appDbContext) : base(appDbContext)
	{
	}
}