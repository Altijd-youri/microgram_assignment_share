using CASbackend.Controllers;
using CASbackend.Models;

namespace CASbackend.Test.Controllers;

[TestClass]
public class OrderControllerTest
{
    [TestMethod]
    public void GetCursusInstanties_ReturnsIEnumerableWithItems()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var result = sut.GetCursusInstanties(41, 2022);
        
        Assert.AreEqual(2, result.Count());
        Assert.IsInstanceOfType(result, typeof(IEnumerable<CursusInstantie>) );
    }
    
    [TestMethod]
    public void GetCursusInstanties_Week41AndYear2022_ReturnsCursusInstanties()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var result = sut.GetCursusInstanties(41, 2022);
        
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

        var result = sut.GetCursusInstanties(41, 2021);
        
        Assert.AreEqual(1, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2021 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
    }
}