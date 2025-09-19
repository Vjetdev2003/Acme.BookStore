using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Orders;

public class CreateOrderDto
{
    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    [StringLength(OrderConsts.MaxCustomerNameLength)]
    public string CustomerName { get; set; } = string.Empty;


    public List<CreateOrderItemDto> Items { get; set; } = new();

}
