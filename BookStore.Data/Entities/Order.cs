using System.ComponentModel.DataAnnotations;

using BookStore.Data.Interfaces;

namespace BookStore.Data.Entities;

public class Order(int clientId, IEnumerable<Book> books) : IBaseEntity<int>
{
	[Key]
	public int Id { get; set; }
	[Required]
	public int ClientId { get; set; } = clientId;
	[Required]
	public IEnumerable<Book> Books { get; set; } = books;
	public decimal TotalPrice { get; set;} = 0;
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
