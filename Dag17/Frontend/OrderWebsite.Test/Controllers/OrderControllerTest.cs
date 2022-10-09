using Microsoft.AspNetCore.Mvc;
using OrderWebsite.Agents;
using OrderWebsite.Controllers;
using OrderWebsite.Models;

namespace OrderWebsite.Test.Controllers;

[TestClass]
public class OrderControllerTest
{
    private IOrderAgent _OrderAgent;
    private OrderController _Sut;
    
    [TestInitialize]
    public void TestInitialize()
    {
        _OrderAgent = new MockOrderAgent();
        _Sut = new OrderController(_OrderAgent);
    }

    #region index (list) tests
    [TestMethod]
    public void Index_returnsViewResult()
    {
        var result = _Sut.Index();
        
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void Index_model_IsListOfOrdersWithTopLevelInformation()
    {
        var result = (ViewResult) _Sut.Index();
        
        Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Order>));
        var contentCheck = (List<Order>) result.Model!;
        Assert.IsTrue(contentCheck.Any(o => 
            o.Datum.Year == 2022 && o.Datum.Month == 12 && o.Datum.Day == 1 &&
            o.Ordernummer == 101
        ));
        Assert.IsTrue(contentCheck.Any(o => 
            o.Datum.Year == 2022 && o.Datum.Month == 12 && o.Datum.Day == 10 &&
            o.Ordernummer == 110
        ));
    }
    #endregion

    #region create tests
    [TestMethod]
    public void Create_returnsViewResult()
    {
        var result = _Sut.Create();
        
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void Create_model_IsNullWithTypeOrder()
    {
        var result = (ViewResult) _Sut.Create();
        
        Assert.IsNull(result.Model);
    }
    #endregion

    #region edit tests
    [TestMethod]
    public void Edit_returnsViewResult()
    {
        var result = _Sut.Edit(101);
        
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    public void Edit_ReturnsViewResult()
    {
        var result = sut.Edit()

        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void Edit_model_IsOrderWithCorrectTopLevelInformation()
    {
        var result = (ViewResult) _Sut.Edit(101);
        
        Assert.IsInstanceOfType(result.Model, typeof(Order));
        var o = (Order) result.Model!;
        Assert.IsTrue(
            o.Datum.Year == 2022 && o.Datum.Month == 12 && o.Datum.Day == 1 &&
            o.Ordernummer == 101
        );
    }
    #endregion

    #region delete tests
    [TestMethod]
    public void Delete_returnsViewResult()
    {
        var result = _Sut.Delete(101);
        
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void Delete_model_IsOrderWithCorrectTopLevelInformation()
    {
        var result = (ViewResult) _Sut.Delete(101);
        
        Assert.IsInstanceOfType(result.Model, typeof(Order));
        var o = (Order) result.Model!;
        Assert.IsTrue(
            o.Datum.Year == 2022 && o.Datum.Month == 12 && o.Datum.Day == 1 &&
            o.Ordernummer == 101
        );
    }
    #endregion

    #region details tests
    [TestMethod]
    public void Details_returnsViewResult()
    {
        var result = _Sut.Details(101);
        
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void Details_model_IsOrderWithCorrectTopLevelInformation()
    {
        var result = (ViewResult) _Sut.Details(101);
        
        Assert.IsInstanceOfType(result.Model, typeof(Order));
        var o = (Order) result.Model!;
        Assert.IsTrue(
            o.Datum.Year == 2022 && o.Datum.Month == 12 && o.Datum.Day == 1 &&
            o.Ordernummer == 101
        );
    }
    #endregion
}