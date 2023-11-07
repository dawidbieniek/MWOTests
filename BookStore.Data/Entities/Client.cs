using System.ComponentModel.DataAnnotations;

using BookStore.Data.Interfaces;

namespace BookStore.Data.Entities;

public class Client(string username, string password) : IBaseEntity<int>
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Username { get; set; } = username;
	[Required]
	public string Password { get; set; } = password;

}
