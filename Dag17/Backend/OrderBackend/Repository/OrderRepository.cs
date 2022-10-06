using Microsoft.EntityFrameworkCore;
using OrderBackend.Models;

namespace OrderBackend.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly DbContextOptions<OrderContext> _options;
    
    public OrderRepository(DbContextOptions<OrderContext> options)
    {
        _options = options;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        using var context = new OrderContext(_options);
        return context.Orders.ToList();
    }
}