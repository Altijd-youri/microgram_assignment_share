using CASbackend.Models;
using CASwebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CASbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CursusInstantie> GetCursusInstanties()
        {
            return new[]
            {
                new CursusInstantie(
                    new Cursus("ASPNET", "Programming in ASP.NET", 5), 
                    new DateOnly(2022, 10, 11)
                ),
                new CursusInstantie(
                    new Cursus("Java", "Programming in Java", 5),
                    new DateOnly(2022, 10, 11)
                )
            };
        }
    }
}
