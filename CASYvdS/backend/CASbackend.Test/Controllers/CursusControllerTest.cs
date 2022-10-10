using CASbackend.Controllers;

namespace CASbackend.Test.Controllers;

[TestClass]
public class OrderControllerTest
{
    [TestMethod]
    public void getOrderList_returnsListOfOrders()
    {
        var repoMock = new CursusMockRepository();
        var sut = new CursusController(repoMock);

        var result = sut.GetCursusInstanties();
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.Id == 200 &&
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Id == 2 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Naam == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
        Assert.IsTrue(result.Any(ci =>
            ci.Id == 100 &&
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Id == 1 &&
            ci.Cursus.Code == "JAVA" && ci.Cursus.Naam == "Programming in Java" && ci.Cursus.Duur == 5
        ));
    }
}