using OrderWebsite.Models;

namespace OrderWebsite.Test.Models;

[TestClass]
public class OrderRowTest
{
    [TestMethod]
    public void getRijTotaal_ReturnsCorrectValue()
    {
        OrderRow sut = new(1, new Product(11, "Goude Cheese", 5M), 2);
        
        decimal result = sut.getRijTotaal();
        
        Assert.AreEqual(10M, result);
    }
}