using OrderBackend.Models;
using OrderBackend.Repository;

namespace OrderBackend.Test.Repository;

public class OrderMockRepository : IOrderRepository
{
    public IEnumerable<Order> GetAllOrders()
    {
        return new List<Order>()
        {
            new(DateTime.Today, 1),
            new(DateTime.Today, 2)
        };
    }
}