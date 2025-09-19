using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Orders;

public interface IOrderItemRepository : IRepository<OrderItem, Guid>
{
    Task<List<OrderItem>> GetListByOrderIdAsync(Guid orderId);
}
