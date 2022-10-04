using OrderWebsite.Models;

namespace OrderWebsite.Test.Models;

[TestClass]
public class OrderTest
{
    [TestMethod]
    public void GetOrderTotaal_ReturnsCorrectValue()
    {
        Order sut = new(new DateTime(2022, 12, 01), 202);
        sut.OrderRows = new List<OrderRow>()
        {
            new(1, new Product(11, "Goude Cheese", 10M), 2),
            new(2, new Product(12, "Edam Cheese", 5M), 1)
        };

        decimal result = sut.GetOrderTotaal();
        
        Assert.AreEqual(25M, result);
    }
}