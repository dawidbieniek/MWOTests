using System.ComponentModel.DataAnnotations;

using BookStore.Data.Interfaces;

namespace BookStore.Data.Entities;

public class Author : IBaseEntity<int>
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string? Name { get; set; }
	[Required]
	public string? Surname { get; set; }
}