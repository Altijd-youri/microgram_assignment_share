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

        [HttpGet]
        public ActionResult Base()
        {
            var weeknummer = GetWeeknummer(DateTime.Today);
            return RedirectToAction("Index", new { weeknummer });
        }

        [HttpGet("cursusoverzicht/{weeknummer:int}")]
        [HttpGet("cursusoverzicht")]
        public ActionResult Index(int weeknummer)
        {
            weeknummer = (weeknummer != 0) ? weeknummer : GetWeeknummer(DateTime.Today);
            var model = new CursusLijst(
                weeknummer,
                _CursusAgent.GetCursusInstanties(weeknummer)
            );
            return View(model);
        }

        [HttpPost("cursusoverzicht/{weeknummer:int}")]
        [HttpPost("cursusoverzicht")]
        public ActionResult Index(CursusLijst model)
        {
            return RedirectToAction("Index", new { weeknummer=model.Weeknummer });
        }
        
        public ActionResult Create()
        {
            var model = new FileUpload();
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(FileUpload planning)
        {
            const int twoMb = 2097152;
            var model = new FileUpload();
            if (planning.File == null)
            {
                model.Message = "";
                model.IsValid = false;
            }
            else
            {
                using (var memoryStream = new MemoryStream())
                {
                    await planning.File.CopyToAsync(memoryStream);
                    if (memoryStream.Length < twoMb)
                    {
                        var file = new FileUpload()
                        {
                            Content = memoryStream.ToArray()
                        };
                        model = _CursusAgent.UploadFile(file);
                    }
                    else
                    {
                        Console.WriteLine("File is too large.");
                    }
                }
            }
            return View(model);
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