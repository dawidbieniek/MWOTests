using System.ComponentModel.DataAnnotations;

using BookStore.Data.Interfaces;

namespace BookStore.Data.Entities;

public class Order : IBaseEntity<int>
{
	[Key]
	public int Id { get; set; }
	[Required]
	public int ClientId { get; set; }
	[Required]
	public IEnumerable<Book>? Books { get; set; }
	public decimal TotalPrice { get; set; } = 0;
	public OrderStatus Status { get; set; } = OrderStatus.Pending;
}

public enum OrderStatus
{
	Pending,
	Processing,
	Shipped,
	Delivered,
	Cancelled
}