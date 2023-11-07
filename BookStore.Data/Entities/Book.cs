using System.ComponentModel.DataAnnotations;

using BookStore.Data.Interfaces;

namespace BookStore.Data.Entities;

public class Book(string title) : IBaseEntity<int>
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Title { get; set; } = title;
	public string? Description { get; set; } = null;
	public int? AuthorId { get; set; } = null;
	public decimal Price { get; set; } = 0M;
	public BookState State { get; set; } = BookState.InStock;
	public bool Returned { get; set; } = false;
}

public enum BookState
{
	InStock,
	Reserved,
	Sold
}