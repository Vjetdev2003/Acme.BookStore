using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Orders;

public class OrderItemAppService : BookStoreAppService, IApplicationService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemAppService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task<List<OrderItemDto>> GetListByOrderIdAsync(Guid orderId)
    {
        var items = await _orderItemRepository.GetListByOrderIdAsync(orderId);
        return ObjectMapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
    }

    public async Task<OrderItemDto> CreateAsync(Guid orderId, CreateOrderItemDto input)
    {
        var orderItem = new OrderItem(
            GuidGenerator.Create(),
            orderId,
            input.BookId,
            input.Quantity,
            input.UnitPrice
        );

        await _orderItemRepository.InsertAsync(orderItem);

        return ObjectMapper.Map<OrderItem, OrderItemDto>(orderItem);
    }

    public async Task UpdateAsync(Guid id, UpdateOrderItemDto input)
    {
        var item = await _orderItemRepository.GetAsync(id);

        item.ChangeQuantity(input.Quantity);
        item.ChangeUnitPrice(input.UnitPrice);

        await _orderItemRepository.UpdateAsync(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _orderItemRepository.DeleteAsync(id);
    }
}
