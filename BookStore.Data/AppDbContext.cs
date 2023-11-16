using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStore.Data;

public class AppDbContext(IConfiguration config, DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
	public IConfiguration Config { get; init; } = config;
	public DbSet<Book> Book { get; set; }
	//public DbSet<Author> Author { get; set; }
	//public DbSet<Client> Client { get; set; }
	//public DbSet<Order> Order { get; set; }

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		return base.SaveChangesAsync(cancellationToken);
	}

	public override int SaveChanges()
	{
		return base.SaveChanges();
	}

	DbSet<TEntity> IAppDbContext.Set<TEntity, TKey>()
	{
		return Set<TEntity>();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlServer(Config["Data:AppConnection:ConnectionString"]);
	}
}