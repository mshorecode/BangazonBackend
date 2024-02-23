using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Product
{
    public int ProductId { get; set; }
    public int SellerId { get; set; }
    public int CategoryId { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public ICollection<Order> Orders { get; set; }
    [Required]
    public string ProductImageUrl { get; set; }
}