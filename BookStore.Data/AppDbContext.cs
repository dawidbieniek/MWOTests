using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public class AppDbContext(string connectionString, DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
	public string ConnectionString { get; init; } = connectionString;
	public DbSet<Book> Book { get; set; }
	public DbSet<Author> Author { get; set; }
	public DbSet<Client> Client { get; set; }
	public DbSet<Order> Order { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlServer(ConnectionString);
	}

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
}