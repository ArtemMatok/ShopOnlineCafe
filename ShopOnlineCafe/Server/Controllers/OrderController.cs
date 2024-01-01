using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineCafe.Server.Repository.OrderRepositories;
using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _userRepository;

        public OrderController(IOrderRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _userRepository.GetAllOrders();    
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]Order order)
        {
            if(order == null)
            {
                return BadRequest("Order is null");
            }
            _userRepository.Add(order);
            return Ok("Created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _userRepository.GetByOrderId(id);
            if(order == null)
            {
                return BadRequest("Order null");
            }
            _userRepository.Delete(order);
            return Ok("Deleted!");
        }



        [HttpGet("GetOrderCount")]
        public async Task<int> GetOrderCount()
        {
            return await _userRepository.GetOrderCount();
        }

        [HttpGet("GetOrderByKod/{kod}")]
        public async Task<Order> GetOrderByKod(string kod)
        {
            return await _userRepository.GetOrderByKod(kod);    
        }

        [HttpPut("UpdateIsDone")]
        public async Task<IActionResult> UpdateIsDone([FromBody] Order order)
        {
            var res = await _userRepository.UpdateIsDone(order);
            if(res)
            {
                return Ok("Update");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
