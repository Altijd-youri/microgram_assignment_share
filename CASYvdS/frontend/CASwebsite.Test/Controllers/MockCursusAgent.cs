using CASwebsite.Agents;
using CASwebsite.Models;

namespace CASwebsite.Test.Controllers;

public class MockCursusAgent : ICursusAgent
{
    
    private static List<CursusInstantie> _list = new List<CursusInstantie>()
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
    public IEnumerable<CursusInstantie> GetCursusInstanties(int weeknummer)
    {
        switch (weeknummer)
        {
            case 1:
                return _list;
            case 40:
                return new List<CursusInstantie>()
                {
                    new (
                        new Cursus("JAVA", "Programming in Java", 5),
                        new DateTime(2022, 10, 9)
                    )
                };
            case 41:
                return new List<CursusInstantie>()
                {
                    new (
                        new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                        new DateTime(2022, 10, 10)
                    )
                };
            default:
                return new List<CursusInstantie>();
        }
    }

    public FileUpload UploadFile(FileUpload planning)
    {
        throw new NotImplementedException();
    }
}