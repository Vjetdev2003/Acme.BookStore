using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Orders;

public class OrderDto : EntityDto<Guid>
{
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public float TotalPrice { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}
