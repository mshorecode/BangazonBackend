using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int PaymentId { get; set; }
    public ICollection<Product> Products { get; set; }
    public bool Status { get; set; }
}

