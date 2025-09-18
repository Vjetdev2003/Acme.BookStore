using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Orders;

public class CreateOrderDto
{
    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    [StringLength(OrderConsts.MaxCustomerNameLength)]
    public string CustomerName { get; set; } = string.Empty;

    public float TotalPrice { get; set; }
}
