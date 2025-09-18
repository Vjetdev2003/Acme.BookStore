using Volo.Abp;

namespace Acme.BookStore.Orders
{
    public class OrderAlreadyExistsException : BusinessException
    {
        public OrderAlreadyExistsException(string customerName)
            : base(BookStoreDomainErrorCodes.OrderAlreadyExists)
        {
            WithData("customerName", customerName);
        }
    }
}