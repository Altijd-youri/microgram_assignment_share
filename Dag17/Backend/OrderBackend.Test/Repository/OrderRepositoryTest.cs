using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OrderBackend.Models;
using OrderBackend.Repository;

namespace OrderBackend.Test.Repository;

[TestClass]
public class OrderRepositoryTest
{
    private readonly DbContextOptions<OrderContext> _options;
    private readonly SqliteConnection _connection;

    public OrderRepositoryTest()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        _options = new DbContextOptionsBuilder<OrderContext>()
            .UseSqlite(_connection)
            .Options;

        using var context = new OrderContext(_options);
        context.Database.EnsureCreated();
    }
    
    [TestMethod]
    public void GetAllOrders_returnsOrders()
    {
        using (var context = new OrderContext(_options))
        {
            var orders = new Order[]
            {
                new(DateTime.Today, 1),
                new(DateTime.Today, 2)
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
        var sut = new OrderRepository(_options);

        var result = sut.GetAllOrders();
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(o => o.Ordernummer == 1));
        Assert.IsTrue(result.Any(o => o.Ordernummer == 2));
    }
}