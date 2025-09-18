using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Orders;

public class UpdateOrderDto
{
    [Required]
    [StringLength(OrderConsts.MaxCustomerNameLength)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    public DateTime OrderDate { get; set; }

    public float TotalPrice { get; set; }
}
