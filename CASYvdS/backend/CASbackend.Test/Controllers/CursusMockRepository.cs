using CASbackend.Models;
using CASbackend.Repository;

namespace CASbackend.Test.Controllers;

public class CursusMockRepository : ICursusRepository
{
    public IEnumerable<CursusInstantie> GetAllCursusInstanties(int weeknummer)
    {
        return new[]
        {
            new CursusInstantie(
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 11)
            ),
            new CursusInstantie(
                new Cursus("JAVA", "Programming in Java", 5),
                new DateTime(2022, 10, 11)
            )
        };
    }

    public InsertStatus CreateCursusInstanties(IEnumerable<CursusInstantie> instanties)
    {
        //TODO test
        throw new NotImplementedException();
    }
}