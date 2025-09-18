using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Orders;

[Authorize(BookStorePermissions.Orders.Default)]
public class OrderAppService : BookStoreAppService, IOrderAppService
{
    private readonly IOrderRepository _orderRepository;
    private readonly OrderManager _orderManager;

    public OrderAppService(IOrderRepository orderRepository, OrderManager orderManager)
    {
        _orderRepository = orderRepository;
        _orderManager = orderManager;
    }

    [Authorize(BookStorePermissions.Orders.Create)]
    public async Task<OrderDto> CreateAsync(CreateOrderDto input)
    {
        var order = await _orderManager.CreateAsync(input.OrderDate, input.CustomerName, input.TotalPrice);

        await _orderRepository.InsertAsync(order);

        return ObjectMapper.Map<Order, OrderDto>(order);
    }

    [Authorize(BookStorePermissions.Orders.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _orderRepository.DeleteAsync(id);
    }

    public async Task<OrderDto> GetAsync(Guid id)
    {
        var order = await _orderRepository.GetAsync(id);
        return ObjectMapper.Map<Order, OrderDto>(order);
    }

    public async Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Order.CustomerName);
        }

        var orders = await _orderRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _orderRepository.CountAsync()
            : await _orderRepository.CountAsync(order => order.CustomerName.Contains(input.Filter));

        return new PagedResultDto<OrderDto>(
            totalCount,
            ObjectMapper.Map<List<Order>, List<OrderDto>>(orders)
        );
    }

    [Authorize(BookStorePermissions.Orders.Edit)]
    public async Task UpdateAsync(Guid id, UpdateOrderDto input)
    {
        var order = await _orderRepository.GetAsync(id);

        if (order.CustomerName != input.CustomerName)
        {
            await _orderManager.ChangeCustomerNameAsync(order, input.CustomerName);
        }
        order.ChangeOrderDate(input.OrderDate);
        order.TotalPrice = input.TotalPrice;

        await _orderRepository.UpdateAsync(order);
    }
}