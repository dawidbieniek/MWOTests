﻿using System.ComponentModel.DataAnnotations;

using BookStore.Data.Interfaces;

namespace BookStore.Data.Entities;

public class Book : IBaseEntity<int>
{
	[Key]
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; } = null;
	public int? AuthorId { get; set; } = null;
	public decimal Price { get; set; } = 0M;
	public bool Returned { get; set; } = false;
}