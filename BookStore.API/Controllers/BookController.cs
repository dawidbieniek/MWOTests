using Microsoft.AspNetCore.Mvc;
using BookStore.Data.Entities;
using BookStore.Data.Interfaces;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IBookRepository bookRepository) : ControllerBase
{
	private readonly IBookRepository _bookRepository = bookRepository;

	[HttpGet("Get")]
	public async IAsyncEnumerable<Book> Get()
	{
		await foreach (Book book in _bookRepository.GetAllAsync())
		{
			yield return book;
		}
	}
}