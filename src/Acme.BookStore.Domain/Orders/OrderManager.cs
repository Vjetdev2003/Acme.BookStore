using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Orders;

public class OrderManager : DomainService
{
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> CreateAsync(DateTime orderDate, string customerName)
    {
        return new Order(
            GuidGenerator.Create(),
            orderDate,
            customerName
        );
    }

    public Task ChangeCustomerNameAsync(Order order, string newName)
    {
        Check.NotNull(order, nameof(order));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        order.ChangeCustomerName(newName);
        return Task.CompletedTask;
    }
}
