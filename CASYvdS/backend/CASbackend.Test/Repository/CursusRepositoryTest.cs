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

    #region GetAllCursusInstanties
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
    #endregion

    #region CreateCursusInstanties
    [TestMethod]
    public void CreateCursusInstanties_InsertAllInstanties()
    {
        var sut = new CursusRepository(_options);
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
        
        sut.CreateCursusInstanties(instanties);
        
        using (var context = new CursusContext(_options))
        {
            CursusInstantie assertionOne = context.CursusInstanties
                .Include(ci => ci.Cursus)
                .Single(ci =>
                ci.Cursus.Code == "ASPNET" &&
                ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10
            );
            Assert.IsNotNull(assertionOne);
            CursusInstantie assertionTwo = context.CursusInstanties
                .Include(ci => ci.Cursus)
                .Single(ci =>
                ci.Cursus.Code == "JAVA" &&
                ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 9
            );
            Assert.IsNotNull(assertionTwo);
        }
    }
    
    [TestMethod]
    public void CreateCursusInstanties_InsertsOne_OnDuplicateEntries()
    {
        var sut = new CursusRepository(_options);
        var instanties = new CursusInstantie[]
        {
            new (
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 10)
            ),
            new (
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 10)
            )
        };
        
        sut.CreateCursusInstanties(instanties);
        
        using (var context = new CursusContext(_options))
        {
            IEnumerable<CursusInstantie> assertionOne = context.CursusInstanties
                .Include(ci => ci.Cursus)
                .Where(ci =>
                    ci.Cursus.Code == "ASPNET" &&
                    ci.StartDatum.Year == 2022 && ci.StartDatum.Month == 10 && ci.StartDatum.Day == 10
                );
            Assert.AreEqual(1, assertionOne.Count());
        }
    }
    
    [TestMethod]
    public void CreateCursusInstanties_InsertsTwo_OnDuplicateCursusWithDifferentDate()
    {
        var sut = new CursusRepository(_options);
        var instanties = new CursusInstantie[]
        {
            new (
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 10)
            ),
            new (
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 17)
            )
        };
        
        sut.CreateCursusInstanties(instanties);
        
        using (var context = new CursusContext(_options))
        {
            IEnumerable<CursusInstantie> result = context.CursusInstanties
                .Include(ci => ci.Cursus)
                .Where(ci =>
                    ci.Cursus.Code == "ASPNET"
                );
            Assert.AreEqual(2, result.Count());

            var startDatum10Exists = result.Any(ci => ci.StartDatum.Day == 10);
            var startDatum17Exists = result.Any(ci => ci.StartDatum.Day == 17);
            
            Assert.IsTrue(startDatum10Exists);
            Assert.IsTrue(startDatum17Exists);
        }
    }
    #endregion
}