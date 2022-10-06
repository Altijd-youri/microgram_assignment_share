using OrderBackend.Models;

namespace OrderBackend.Repository;

public interface IOrderRepository
{
    public IEnumerable<Order> GetAllOrders();
}