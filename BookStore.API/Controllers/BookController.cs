using Microsoft.AspNetCore.Mvc;
using BookStore.Data.Interfaces;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IBookRepository bookRepository) : ControllerBase
{
	private readonly IBookRepository _bookRepository = bookRepository;

	[HttpGet("Get")]
	public ActionResult Get()
	{
		return new OkObjectResult(_bookRepository.GetAll());
	}
}