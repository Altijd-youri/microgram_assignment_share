using System.Globalization;
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
        
        [HttpGet("{weeknummer:int}")]
        [HttpGet("")]
        public ActionResult Index(int weeknummer)
        {
            weeknummer = (weeknummer != 0) ? weeknummer : GetWeeknummer(DateTime.Today);
            var model = new CursusLijst(
                weeknummer,
                _CursusAgent.GetCursusInstanties(weeknummer)
            );
            return View(model);
        }

        [HttpPost("{weeknummer:int}")]
        [HttpPost("")]
        public ActionResult Index(CursusLijst model)
        {
            return RedirectToAction("Index", new { weeknummer=model.Weeknummer });
        }
        
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }
        
        private static int GetWeeknummer(DateTime date)
        {
            Calendar cal = new GregorianCalendar();
            DayOfWeek firstDay = DayOfWeek.Sunday;
            CalendarWeekRule rule = CalendarWeekRule.FirstFourDayWeek;
            var weeknummer = cal.GetWeekOfYear(date, rule, firstDay);
            return weeknummer;
        }
    }
}