using CASwebsite.Agents;
using CASwebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CASwebsite.Controllers
{
    public class CursusController : Controller
    {
        private readonly ICursusAgent _CursusAgent;

        public CursusController(ICursusAgent cursusAgent)
        {
            _CursusAgent = cursusAgent;
        }
        public ActionResult Index()
        {
            IEnumerable<CursusInstantie> model = _CursusAgent.GetCursusInstanties();
            return View(model);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }
    }
}