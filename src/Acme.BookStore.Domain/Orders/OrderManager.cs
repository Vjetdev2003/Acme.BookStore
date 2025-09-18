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

    public async Task<Order> CreateAsync(DateTime orderDate,string customerName, float totalPrice)
    {
        Check.NotNullOrWhiteSpace(customerName, nameof(customerName));

        return new Order(GuidGenerator.Create(), orderDate,customerName, totalPrice);
    }

    public Task ChangeCustomerNameAsync(Order order, string newName)
    {
        Check.NotNull(order, nameof(order));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        order.ChangeCustomerName(newName);
        return Task.CompletedTask;
    }
}
