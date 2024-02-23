using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    public bool Seller { get; set; }
    [Required]
    public string Uid { get; set; }
}