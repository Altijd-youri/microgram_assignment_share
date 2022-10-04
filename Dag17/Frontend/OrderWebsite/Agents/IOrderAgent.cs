using OrderWebsite.Models;

namespace OrderWebsite.Agents;

public interface IOrderAgent
{
    public IEnumerable<Order> GetOrderList();
    public Order GetOrder(long id);
}