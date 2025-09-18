using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Orders;

public class Order : FullAuditedAggregateRoot<Guid>
{
    public DateTime OrderDate { get; private set; }
    public string CustomerName { get; private set; }
    public float TotalPrice { get; set; }

    private Order()
    {
        /* For ORM/Deserialization */
    }

    internal Order(Guid id, DateTime orderDate, string customerName, float totalPrice)
        : base(id)
    {
        SetCustomerName(customerName);
        OrderDate = orderDate;
        TotalPrice = totalPrice;
    }

    internal Order ChangeCustomerName(string name)
    {
        SetCustomerName(name);
        return this;
    }
    public void ChangeOrderDate(DateTime newDate)
    {
        OrderDate = newDate;
    }

    private void SetCustomerName(string name)
    {
        CustomerName = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: OrderConsts.MaxCustomerNameLength
        );
    }
}
