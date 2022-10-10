using CASbackend.Models;
using CASbackend.Repository;

namespace CASbackend.Test.Controllers;

public class CursusMockRepository : ICursusRepository
{
    public IEnumerable<CursusInstantie> GetAllCursusInstanties()
    {
        return new[]
        {
            new CursusInstantie(
                200,
                new Cursus(2,"ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 11)
            ),
            new CursusInstantie(
                100,
                new Cursus(1, "JAVA", "Programming in Java", 5),
                new DateTime(2022, 10, 11)
            )
        };
    }
}