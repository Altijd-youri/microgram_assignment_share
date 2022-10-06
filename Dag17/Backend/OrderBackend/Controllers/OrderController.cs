using Microsoft.AspNetCore.Mvc;
using OrderBackend.DataTransferObject;
using OrderBackend.Repository;

namespace OrderBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<OrderTopLevelDto> GetOrderList()
        {
            return _orderRepository.GetAllOrders().Select(o => new OrderTopLevelDto(o.Ordernummer, o.Datum));
        }
    }
}
