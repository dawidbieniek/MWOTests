using BookStore.Data;
using BookStore.Data.Interfaces;
using BookStore.Data.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BookStore.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddScoped<IBookRepository, BookRepository>()
				.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["Data:AppConnection:ConnectionString"]))
				.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>()!);

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}