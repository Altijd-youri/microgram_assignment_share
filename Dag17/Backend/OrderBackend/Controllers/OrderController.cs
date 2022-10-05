using Microsoft.AspNetCore.Mvc;
using OrderBackend.DataTransferObject;

namespace OrderBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<OrderTopLevelDto> GetOrderList()
        {
            // TODO implement with repository
            return new List<OrderTopLevelDto>()
            {
                new(1, DateTime.Today),
                new(2, DateTime.Today)
            };
        }
    }
}
