using Flurl.Http.Testing;
using OrderWebsite.Agents;

namespace OrderWebsite.Test.Agents;

[TestClass]
public class OrderAgentTest : IDisposable
{
    private HttpTest _httpTest;

    [TestInitialize]
    public void CreateHttpTest()
    {
        _httpTest = new HttpTest();
    }

    [TestCleanup]
    public void DisposeHttpTest()
    {
       Dispose();
    }
    
    public void Dispose()
    {
        _httpTest.Dispose();
    }
    
    [TestMethod]
    public void GetOrderList_CallsCorrectUrl()
    {
        _httpTest.RespondWithJson(new [] {
            new { Ordernummer=1, Datum="2022-10-09T00:00:00" },
            new { Ordernummer=2, Datum="2022-10-10T00:00:00" },
        });
        var sut = new OrderAgent("http://test.url");
        
        sut.GetOrderList();
        
        _httpTest.ShouldHaveCalled("http://test.url/api/order");
    }

    [TestMethod]
    public void GetOrderList_ReturnsListOfOrders()
    {
        _httpTest.RespondWithJson(new [] {
            new { Ordernummer=1, Datum="2022-10-09T00:00:00" },
            new { Ordernummer=2, Datum="2022-10-10T00:00:00" },
        });
        var sut = new OrderAgent("http://test.url");
        
        var result = sut.GetOrderList();
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(o => new DateTime(2022, 10, 9).Equals(o.Datum) && o.Ordernummer == 1));
        Assert.IsTrue(result.Any(o => new DateTime(2022, 10, 10).Equals(o.Datum) && o.Ordernummer == 2));
    }
}