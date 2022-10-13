using CASbackend.Repository;
using CASbackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CASbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusController : ControllerBase
    {
        private readonly ICursusRepository _CursusRepository;

        public CursusController(ICursusRepository cursusRepository)
        {
            _CursusRepository = cursusRepository;
        }

        [HttpGet("{jaar}/{week}")]
        public ActionResult GetCursusInstanties(int week, int jaar)
        {
            IEnumerable<CursusInstantie> instanties = _CursusRepository.GetAllCursusInstanties(week, jaar);
            return Ok(instanties);
        }
        
        [HttpGet("details/{code}/{datum}")]
        public ActionResult GetCursusInstantie(string code, string datum)
        {
            CursusInstantie? instantie = _CursusRepository.GetCursusInstantie(code, datum);
            if (instantie != null) return Ok(instantie);
            return NotFound();
        }
    }
}
