using Microsoft.AspNetCore.Mvc;
using OrderWebsite.Agents;
using OrderWebsite.Models;

namespace OrderWebsite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAgent _orderAgent;

        public OrderController(IOrderAgent orderAgent)
        {
            _orderAgent = orderAgent;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> model = _orderAgent.GetOrderList();
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
        
        public IActionResult Edit(long id)
        {
            Order model = _orderAgent.GetOrder(id);
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            // TODO: call agent
            return View(order);
        }
        
        public IActionResult Delete(long id)
        {
            Order model = _orderAgent.GetOrder(id);
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Delete(Order order)
        {
            // TODO: call agent
            Order model = order;
            return View(model);
        }
        
        public IActionResult Details(long id)
        {
            Order model = _orderAgent.GetOrder(id);
            return View(model);
        }
    }
}