using OrderWebsite.Agents;
using OrderWebsite.Models;

namespace OrderWebsite.Test.Controllers;

public class MockOrderAgent : IOrderAgent
{
    public IEnumerable<Order> GetOrderList()
    {
        return new List<Order>
        {
            new (new DateTime(2022, 12, 01), 101),
            new (new DateTime(2022, 12, 10), 110)
        };
    }

    public Order GetOrder(long id)
    {
        Order order = new(new DateTime(2022, 12, 01), id);
        order.OrderRows = new List<OrderRow>()
        {
            new(1, new Product(11, "Goude Cheese", 10M), 2),
            new(2, new Product(12, "Edam Cheese", 5M), 1)
        };
        return order;
    }
}