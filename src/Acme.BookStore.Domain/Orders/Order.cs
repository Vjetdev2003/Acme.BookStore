using Acme.BookStore.Orders;
using System.Collections.Generic;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;
using System.Linq;

public class Order : Entity<Guid>
{
    public DateTime OrderDate { get; private set; }
    public string CustomerName { get; private set; }
    public float TotalPrice { get;  set; }

    public List<OrderItem> Items { get; private set; } = new();

    private Order() { } // EF Core cần

    public Order(Guid id, DateTime orderDate, string customerName) : base(id)
    {
        OrderDate = orderDate;
        CustomerName = customerName;
    }

    public void AddItem(Guid bookId, int quantity, float unitPrice)
    {
        var item = new OrderItem(Id,Guid.NewGuid(), bookId, quantity, unitPrice);
        Items.Add(item);
        RecalculateTotal();
    }

    private void RecalculateTotal()
    {
        TotalPrice = Items.Sum(x => x.UnitPrice * x.Quantity);
    }

    public void ChangeCustomerName(string newName)
    {
        CustomerName = newName;
    }

    public void ChangeOrderDate(DateTime date)
    {
        OrderDate = date;
    }
}
