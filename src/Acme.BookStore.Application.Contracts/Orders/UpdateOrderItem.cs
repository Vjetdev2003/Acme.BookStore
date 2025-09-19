using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Orders;

public class UpdateOrderItemDto
{
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    public float UnitPrice { get; set; }
}
