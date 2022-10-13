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

        [HttpGet("")]
        [HttpGet("cursusoverzicht")]
        public ActionResult Base()
        {
            var today = DateTime.Today;
            var week = ISOWeek.GetWeekOfYear(today);
            var jaar = ISOWeek.GetYear(today);
            
            return RedirectToAction("Index", new { jaar, week });
        }

        [HttpGet("cursusoverzicht/{jaar:int}/{week:int}")]
        public ActionResult Index(int week, int jaar)
        {
            try
            {
                var weeknumber = new Weeknumber(week, jaar);
                var model = new CursusLijst(weeknumber, _CursusAgent.GetCursusInstanties(weeknumber.Week, weeknumber.Jaar));
                return View(model);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("Jaar en week buiten het valide bereik.");
            }
        }

        [HttpPost("cursusoverzicht/{jaar:int}/{week:int}")]
        [HttpPost("cursusoverzicht")]
        public ActionResult Index(CursusLijst model)
        {
            var week = model.Weeknummer.Week;
            var jaar = model.Weeknummer.Jaar;
            
            return RedirectToAction("Index", new { jaar, week });
        }
        
        public ActionResult Create()
        {
            var model = new FileUpload();
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(FileUpload inModel)
        {
            var outModel = new FileUpload();
            if (inModel.File == null)
            {
                outModel.Message = "";
                outModel.IsValid = false;
            }
            else
            {
                using (var memoryStream = new MemoryStream())
                {
                    await inModel.File.CopyToAsync(memoryStream);
                    var modelForBackend = new FileUpload()
                    {
                        Content = memoryStream.ToArray(),
                        BeginFilter = inModel.BeginFilter,
                        EindFilter = inModel.EindFilter
                    };
                    outModel = _CursusAgent.UploadFile(modelForBackend);
                }
            }
            return View(outModel);
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