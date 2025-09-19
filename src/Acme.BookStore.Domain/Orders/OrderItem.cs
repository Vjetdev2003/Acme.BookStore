using Acme.BookStore.Books;
using System;
using Volo.Abp.Domain.Entities;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; private set; }
    public Guid BookId { get; private set; }
    public int Quantity { get; private set; }
    public float UnitPrice { get; private set; }

    // Navigation
    public Order Order { get; private set; }
    public Book Book { get; private set; }     // 🔑 để EF map chính xác quan hệ với Book

    private OrderItem() { }

    public OrderItem(Guid id, Guid orderId, Guid bookId, int quantity, float unitPrice)
        : base(id)
    {
        OrderId = orderId;
        BookId = bookId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public void ChangeQuantity(int quantity) => Quantity = quantity;
    public void ChangeUnitPrice(float unitPrice) => UnitPrice = unitPrice;
}
