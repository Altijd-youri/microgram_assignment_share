using CASwebsite.Agents;
using Flurl.Http.Testing;
namespace CASwebsite.Test.Agents;

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
    public void GetCursusInstanties_CallsCorrectUrl()
    {
        _httpTest.RespondWithJson(new [] {
            new { Ordernummer=1, Datum="2022-10-09T00:00:00" },
            new { Ordernummer=2, Datum="2022-10-10T00:00:00" },
        });
        var sut = new CursusAgent("http://test.url");
        var week = 1;
        var jaar = 2022;
        
        sut.GetCursusInstanties(week, jaar);
        
        _httpTest.ShouldHaveCalled("http://test.url/api/cursus/2022/1");
    }

    [TestMethod]
    public void GetCursusInstanties_ReturnsListCurusInstanties()
    {
        _httpTest.RespondWithJson( new [] {
             new {
                Id=200,
                Cursus= new {
                    Id=2,
                    Code="ASPNET",
                    Titel="Programming in ASP.NET",
                    Duur=5
                },
                Startdatum="2022-10-11T00:00:00"
            },
            new {
                Id=100,
                Cursus= new {
                    Id=1,
                    Code="JAVA",
                    Titel="Programming in Java",
                    Duur=5
                },
                Startdatum="2022-10-10T00:00:00"
            }
        });
        var sut = new CursusAgent("http://test.url");
        var WeekImportantForMock = 1;
        var JaarImportantForMock = 2022;
        
        var result = sut.GetCursusInstanties(WeekImportantForMock, JaarImportantForMock);
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.Id == 200 &&
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Id == 2 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
        Assert.IsTrue(result.Any(ci =>
            ci.Id == 100 &&
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10 &&
            ci.Cursus.Id == 1 &&
            ci.Cursus.Code == "JAVA" && ci.Cursus.Titel == "Programming in Java" && ci.Cursus.Duur == 5
        ));
    }
}