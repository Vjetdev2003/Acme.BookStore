using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Orders;

public class EfCoreOrderItemRepository
    : EfCoreRepository<BookStoreDbContext, OrderItem, Guid>, IOrderItemRepository
{
    public EfCoreOrderItemRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<List<OrderItem>> GetListByOrderIdAsync(Guid orderId)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.Where(x => x.OrderId == orderId).ToListAsync();
    }
}
