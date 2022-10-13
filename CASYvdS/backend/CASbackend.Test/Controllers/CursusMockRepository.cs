using CASbackend.Models;
using CASbackend.Repository;

namespace CASbackend.Test.Controllers;

public class CursusMockRepository : ICursusRepository
{
    private ICursusRepository _cursusRepositoryImplementation;

    public IEnumerable<CursusInstantie> GetAllCursusInstanties(int week, int jaar)
    {
        switch (jaar)
        {
            case 2021:
                return new[]
                {
                    new CursusInstantie(
                        new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                        new DateTime(2021, 10, 11)
                    )
                };
            default:
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
        
    }

    public OutFileUpload CreateCursusInstanties(IEnumerable<CursusInstantie> instanties)
    {
        //TODO test
        throw new NotImplementedException();
    }

    public CursusInstantie? GetCursusInstantie(string code, string datum)
    {
        switch (code)
        {
            case "ASPNET":
                return new CursusInstantie(
                    new Cursus("ASPNET", "Programming in ASP.NET", 5),
                    new DateTime(2022, 10, 10)
                );
        }
        return null;
    }
}