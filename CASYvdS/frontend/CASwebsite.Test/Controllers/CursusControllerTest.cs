using CASwebsite.Agents;
using CASwebsite.Controllers;
using CASwebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CASwebsite.Test.Controllers;

[TestClass]
public class CursusControllerTest
{
    private ICursusAgent _cursusAgent;
    private CursusController _sut;
    private Weeknumber _mockedWeeknummerFullList = new (1, 2022);
    
    [TestInitialize]
    public void TestInitialize()
    {
        _cursusAgent = new MockCursusAgent();
        _sut = new CursusController(_cursusAgent);
    }

    #region Index tests
    [TestMethod]
    public void Index_ReturnsViewResult()
    {
        var result = _sut.Index(_mockedWeeknummerFullList.Week, _mockedWeeknummerFullList.Jaar);

        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void IndexModel_ContainsCorrectCursusInstanties()
    {
        var result = ((ViewResult) _sut.Index(_mockedWeeknummerFullList.Week, _mockedWeeknummerFullList.Jaar)).Model;
        
        Assert.IsInstanceOfType(result, typeof(CursusLijst));
        var cursusLijst = (CursusLijst) result!;
        var instanties = cursusLijst.CursusInstanties;
        Assert.AreEqual(2, instanties.Count());
        Assert.IsTrue(instanties.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
        Assert.IsTrue(instanties.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 9 &&
            ci.Cursus.Code == "JAVA" && ci.Cursus.Titel == "Programming in Java" && ci.Cursus.Duur == 5
        ));
    }
    
    [TestMethod]
    public void IndexWithWeek41AndYear2022_Model_ContainsCorrectCursusInstanties()
    {
        var result = ((ViewResult) _sut.Index(41, 2022)).Model;
        
        Assert.IsInstanceOfType(result, typeof(CursusLijst));
        var resultObject = (CursusLijst) result!;
        var instanties = resultObject.CursusInstanties;
        Assert.AreEqual(1, instanties.Count());
        Assert.IsTrue(instanties.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
    }
    
    [TestMethod]
    public void IndexWithWeek53AndYear2022_ReturnsBadRequest()
    {
        var result = _sut.Index(53, 2022);
        
        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }
    
    [TestMethod]
    public void IndexWithWeek41AndYear2021_Model_ContainsCorrectCursusInstanties()
    {
        var result = ((ViewResult) _sut.Index(41, 2021)).Model;
        
        Assert.IsInstanceOfType(result, typeof(CursusLijst));
        var resultObject = (CursusLijst) result!;
        var instanties = resultObject.CursusInstanties;
        Assert.AreEqual(1, instanties.Count());
        Assert.IsTrue(instanties.Any(ci =>
            ci.StartDatum.Year == 2021 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
    }
    
    [TestMethod]
    public void IndexModel_ContainsCorrectWeeknummer()
    {
        var result = ((ViewResult) _sut.Index(40, 2022)).Model;
        
        Assert.IsInstanceOfType(result, typeof(CursusLijst));
        var cursusLijst = (CursusLijst) result!;
        Assert.AreEqual(40, cursusLijst.Weeknummer.Week);
    }
    
    [TestMethod]
    public void IndexModel_IsInstanceOf_CursusLijst()
    {
        var result = ((ViewResult) _sut.Index(_mockedWeeknummerFullList.Week, _mockedWeeknummerFullList.Jaar)).Model;
        
        Assert.IsInstanceOfType(result, typeof(CursusLijst));
    }
    
    [TestMethod]
    public void IndexPost_ReturnsRedirectAction()
    {
        var cursusLijst = new CursusLijst();
        cursusLijst.Weeknummer = new Weeknumber(51, 2022);

        var result = _sut.Index(cursusLijst);
        
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
    }
    #endregion

    [TestMethod]
    public void Create_ReturnsViewResult()
    {
        var result = _sut.Create();

        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod]
    public void Base_ReturnsViewResult()
    {
        var result = _sut.Base();

        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
    }
    
    [TestMethod]
    public void Details_ReturnsViewResult()
    {
        var importantCursuscodeForMock = "ASPNET";
        var dateThatIsNotUsedInMock = "10-10-2022";
        
        var result = _sut.Details(importantCursuscodeForMock, dateThatIsNotUsedInMock);

        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
    
    [TestMethod]
    public void Details_NonExistingCursusInstantie_ReturnsRedirectActionResult()
    {
        var importantCursuscodeForMock = "NONEXISTENT";
        var dateThatIsNotUsedInMock = "10-10-2022";
        
        var result = _sut.Details(importantCursuscodeForMock, dateThatIsNotUsedInMock);
        
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
    }
}