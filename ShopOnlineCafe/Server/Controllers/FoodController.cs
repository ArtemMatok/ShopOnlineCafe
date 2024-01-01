using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineCafe.Server.Repository;
using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;

        public FoodController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IEnumerable<Food>> GetAllFoods()
        {
            return await _foodRepository.GetAllFoods();
        }


        [HttpGet("GetAllProductsByCategory/{category}")]
        public async Task<IEnumerable<Food>> GetAllProductsByCategory(string category)
        {
            return await _foodRepository.GetAllFoodsByCategory(category);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<Food> GetProductById(int id)
        {
            return await _foodRepository.GetById(id);
        }

        [HttpPost("Create")]
       
        public IActionResult CreateFood([FromBody]Food food)
        {
            if (food == null)
            {
                return BadRequest("food is null");
            }
            if (_foodRepository.Create(food))
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateFood(int id, [FromBody] Food food)
        {
            if (id == 0)
            {
                return BadRequest("Id = 0");
            }
            var foodUpdate = await _foodRepository.GetById(id);
            if (food != null)
            {
                foodUpdate.Name = food.Name;
                foodUpdate.Price = food.Price;
                foodUpdate.Image = food.Image; 
                foodUpdate.Category = food.Category;
                _foodRepository.Update(foodUpdate);
                return Ok("Update Success");
            }
            else
            {
                return BadRequest("Something went wrong");
            }


        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            if (id != 0)
            {
                var foodDelete = await _foodRepository.GetById(id);
                _foodRepository.Delete(foodDelete);
                return Ok("Success deleted");
            }
            else
            {
                return BadRequest("Something went wrong");
            }

        }
    }
}
