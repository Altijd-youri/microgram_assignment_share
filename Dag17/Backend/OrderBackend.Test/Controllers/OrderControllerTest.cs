using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OrderBackend.Models;
using OrderBackend.Repository;
using OrderBackend.Test.Repository;

namespace OrderBackend.Test.Controllers;

[TestClass]
public class OrderControllerTest
{
    [TestMethod]
    public void getOrderList_returnsListOfOrders()
    {
        var repoMock = new OrderMockRepository();
        var sut = new OrderController(repoMock);

        var result = sut.GetOrderList();
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(o => o.Ordernummer == 1));
        Assert.IsTrue(result.Any(o => o.Ordernummer == 2));
    }
}