using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models;

public class Payment
{
    public int PaymentId { get; set; }
    [Required]
    public string PaymentType { get; set; }
}
