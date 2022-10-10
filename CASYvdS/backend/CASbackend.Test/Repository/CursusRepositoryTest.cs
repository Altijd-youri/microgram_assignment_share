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
    public void GetAllOrders_returnsOrders()
    {
        using (var context = new CursusContext(_options))
        {
            var instanties = new CursusInstantie[]
            {
                new (
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 11)
                ),
                new (
                    new Cursus("JAVA", "Programming in Java", 5),
                    new DateTime(2022, 10, 11)
                )
            };
            context.CursusInstanties.AddRange(instanties);
            context.SaveChanges();
        }
        var sut = new CursusRepository(_options);

        var result = sut.GetAllCursusInstanties();
        
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "ASPNET" && ci.Cursus.Naam == "Programming in ASP.NET" && ci.Cursus.Duur == 5
        ));
        Assert.IsTrue(result.Any(ci =>
            ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 11 &&
            ci.Cursus.Code == "JAVA" && ci.Cursus.Naam == "Programming in Java" && ci.Cursus.Duur == 5
        ));
    }
}