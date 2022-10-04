using OrderWebsite.Models;

namespace OrderWebsite.Agents;

public class OrderAgent : IOrderAgent
{
    public IEnumerable<Order> GetOrderList()
    {
        throw new NotImplementedException();
    }

    public Order GetOrder(long id)
    {
        throw new NotImplementedException();
    }
}