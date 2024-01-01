using Microsoft.EntityFrameworkCore;
using ShopOnlineCafe.Server.Data;
using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Food food)
        {
            _context.Foods.Add(food);
            return Save();
        }

        public bool Delete(Food food)
        {
            _context.Foods.Remove(food);
            return Save();
        }

        public async Task<IEnumerable<Food>> GetAllFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<IEnumerable<Food>> GetAllFoodsByCategory(string category)
        {
            return await _context.Foods.Where(x=>x.Category == category).ToListAsync();
        }

        public async Task<Food> GetById(int id)
        {
            return await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Food food)
        {
            _context.Foods.Update(food);
            return Save();
        }
    }
}
