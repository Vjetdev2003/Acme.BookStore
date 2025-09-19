using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Orders;

public class OrderItemDto : EntityDto<Guid>
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public float UnitPrice { get; set; }
}
