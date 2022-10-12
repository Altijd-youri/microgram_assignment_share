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

        [HttpGet("week/{weeknummer}")]
        public IEnumerable<CursusInstantie> GetCursusInstanties(int weeknummer)
        {
            return _CursusRepository.GetAllCursusInstanties(weeknummer);
        }
    }
}