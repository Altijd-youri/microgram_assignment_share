using Microsoft.AspNetCore.Mvc;
using OrderWebsite.Models;

namespace OrderWebsite.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Order> model = new List<Order>();
            return View(model);
        }

        public IActionResult Create()
        {
            Order model = null;
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create(Order order)
        {
            // TODO: call agent
            return View(order);
        }
        
        public IActionResult Edit()
        {
            Order model = new Order(new DateTime(), 101); // TODO: call agent
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            // TODO: call agent
            return View(order);
        }
        
        public IActionResult Delete()
        {
            Order model = new Order(new DateTime(), 101); // TODO: call agent
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Delete(Order order)
        {
            // TODO: call agent
            Order model = order;
            return View(model);
        }
        
        public IActionResult Details()
        {
            Order model = new Order(new DateTime(), 111); // TODO: call agent
            return View(model);
        }
    }
}