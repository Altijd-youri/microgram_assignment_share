using CASbackend.Models;
using CASbackend.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CASbackend.Test.Repository;

[TestClass]
public class CursusRepositoryTest
{
    private readonly DbContextOptions<CursusContext> _options;
    private readonly SqliteConnection _connection;

    public CursusRepositoryTest()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        _options = new DbContextOptionsBuilder<CursusContext>()
            .UseSqlite(_connection)
            .Options;

        using var context = new CursusContext(_options);
        context.Database.EnsureCreated();
    }
    
    [TestMethod]
    public void GetAllCursusInstanties_Week40_ReturnsCurssusen()
    {
        using (var context = new CursusContext(_options))
        {
            var instanties = new CursusInstantie[]
            {
                new (
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 10)
                ),
                new (
                    new Cursus("JAVA", "Programming in Java", 5),
                    new DateTime(2022, 10, 9)
                )
            };
            context.CursusInstanties.AddRange(instanties);
            context.SaveChanges();
        }
        var sut = new CursusRepository(_options);

        var result = sut.GetAllCursusInstanties(41);
        
        Assert.AreEqual(1, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Titel == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
    }
    
    [TestMethod]
    public void GetAllCursusInstanties_Week40_ReturnsCursussen()
    {
        using (var context = new CursusContext(_options))
        {
            var instanties = new CursusInstantie[]
            {
                new (
                    new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                    new DateTime(2022, 10, 10)
                ),
                new (
                    new Cursus("JAVA", "Programming in Java", 5),
                    new DateTime(2022, 10, 9)
                )
            };
            context.CursusInstanties.AddRange(instanties);
            context.SaveChanges();
        }
        var sut = new CursusRepository(_options);

        var result = sut.GetAllCursusInstanties(40);
        
        Assert.AreEqual(1, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 9 &&
            ci.Cursus.Code == "JAVA" && ci.Cursus.Titel == "Programming in Java" && ci.Cursus.Duur == 5
        ));
    }
}