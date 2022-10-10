using CASwebsite.Agents;
using CASwebsite.Controllers;
using CASwebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CASwebsite.Test.Controllers;

[TestClass]
public class CursusControllerTest
{
    private ICursusAgent _CursusAgent;
    private CursusController _Sut;
    
    [TestInitialize]
    public void TestInitialize()
    {
        _CursusAgent = new MockCursusAgent();
        _Sut = new CursusController(_CursusAgent);
    }
    
    [TestMethod]
    public void Index_ReturnsViewResult()
    {
        var result = _Sut.Index();

        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void IndexModel_ContainsCorrectData()
    {
        var result = (ViewResult) _Sut.Index();
        
        Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<CursusInstantie>));
        var content = (IEnumerable<CursusInstantie>) result.Model!;
        Assert.AreEqual(2, content.Count());
        Assert.IsTrue(content.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Naam == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
        Assert.IsTrue(content.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10 &&
            ci.Cursus.Code == "JAVA" && ci.Cursus.Naam == "Programming in Java" && ci.Cursus.Duur == 5
        ));
    }

    [TestMethod]
    public void Create_ReturnsViewResult()
    {
        var result = _Sut.Create();

        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
}