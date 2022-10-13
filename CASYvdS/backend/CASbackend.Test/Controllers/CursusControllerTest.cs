using CASbackend.Controllers;
using CASbackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CASbackend.Test.Controllers;

[TestClass]
public class OrderControllerTest
{
    #region GetCursusInstanties
    [TestMethod]
    public void GetCursusInstanties_ReturnsOkObjectResultWithListOfCursusInstanties()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var response = sut.GetCursusInstanties(41, 2022);
        
        var result = (OkObjectResult)response;
        Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        Assert.IsInstanceOfType(result.Value, typeof(IEnumerable<CursusInstantie>));
    }
    
    [TestMethod]
    public void GetCursusInstanties_ReturnsIEnumerableWithItems()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var response = sut.GetCursusInstanties(41, 2022);
        
        var result = (IEnumerable<CursusInstantie>) ((OkObjectResult)response).Value!;
        Assert.AreEqual(2, result.Count());
        Assert.IsInstanceOfType(result, typeof(IEnumerable<CursusInstantie>) );
    }
    
    [TestMethod]
    public void GetCursusInstanties_Week41AndYear2022_ReturnsCursusInstanties()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);
        
        var response = sut.GetCursusInstanties(41, 2022);
        
        var result = (IEnumerable<CursusInstantie>) ((OkObjectResult)response).Value!;
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "JAVA" && ci.Cursus.Titel == "Programming in Java" && ci.Cursus.Duur == 5
        ));
    }
    
    [TestMethod]
    public void GetCursusInstanties_Week41AndYear2021_ReturnsCursusInstanties()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);
        
        var response = sut.GetCursusInstanties(41, 2021);
        
        var result = (IEnumerable<CursusInstantie>) ((OkObjectResult)response).Value!;
        Assert.AreEqual(1, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2021 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
    }
    #endregion

    #region GetCursusInstantie
    [TestMethod]
    public void GetCursusInstantie_ReturnsOkObjectWithResultCursusInstanties()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var response = sut.GetCursusInstantie("ASPNET", "10-10-2022");
        
        var result = (OkObjectResult)response;
        Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        Assert.IsInstanceOfType(result.Value, typeof(CursusInstantie));
    }
    
    [TestMethod]
    public void GetCursusInstantie_ReturnsCorrectCursusInstantie()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var response = sut.GetCursusInstantie("ASPNET", "10-10-2022");
        
        var result = (CursusInstantie) ((OkObjectResult)response).Value!;
        Assert.IsTrue(
            result.CursusCode == "ASPNET" && 
            result.StartDatum.Day == 10 && result.StartDatum.Month == 10 && result.StartDatum.Year == 2022 &&
            result.Cursus.Duur == 5 && result.Cursus.Code == "ASPNET" && result.Cursus.Titel == "Programming in ASP.NET"
        );
    }
    
    [TestMethod]
    public void GetCursusInstantie_ReturnsNotFoundOnNonExistingCursusInstantie()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var response = sut.GetCursusInstantie("NONEXISTENT", "10-10-2022");
        
        Assert.IsInstanceOfType(response, typeof(NotFoundResult));
    }
    

    #endregion
}