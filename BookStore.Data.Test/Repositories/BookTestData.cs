using System.Text.Json;

using BookStore.Data.Entities;

namespace BookStore.Data.Test.Repositories;

public static class BookTestData
{
	public static readonly string BookObjectJsonPath = "Repositories/Data/BookData.json";
	/// <exception cref="FormatException">File containing book data is invalid</exception>
	public static Book TestBook
	{
		get
		{
			string jsonString = File.ReadAllText(Path.GetRelativePath(Directory.GetCurrentDirectory(), BookObjectJsonPath));
			Book? book = JsonSerializer.Deserialize<Book>(jsonString);
			return book is null ? throw new FormatException("File content is not correct") : book;
		}
	}
}