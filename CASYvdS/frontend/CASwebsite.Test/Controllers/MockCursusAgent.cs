using CASwebsite.Agents;
using CASwebsite.Models;

namespace CASwebsite.Test.Controllers;

public class MockCursusAgent : ICursusAgent
{
    public IEnumerable<CursusInstantie> GetCursusInstanties()
    {
        return new List<CursusInstantie>()
        {
            new CursusInstantie(
                new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                new DateTime(2022, 10, 11)
            ),
            new CursusInstantie(
                new Cursus("JAVA", "Programming in Java", 5),
                new DateTime(2022, 10, 10)
            )
        };
    }
}