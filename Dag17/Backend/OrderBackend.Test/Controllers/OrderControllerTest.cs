namespace OrderBackend.Test.Controllers;

[TestClass]
public class OrderControllerTest
{
    [TestMethod]
    public void getOrderList_returnsListOfOrders()
    {
        var sut = new OrderController();

        var result = sut.GetOrderList();
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(o => o.Id == 1));
        Assert.IsTrue(result.Any(o => o.Id == 2));
    }
}