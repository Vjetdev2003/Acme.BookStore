namespace Acme.BookStore.Orders
{
    public enum OrderState : byte
    {
        Placed = 0,
        Delivered = 1,
        Canceled = 2
    }
}