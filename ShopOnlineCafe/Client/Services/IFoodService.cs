using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Client.Services
{
    public interface IFoodService
    {
        Task<IEnumerable<Food>> GetAllFoods();
        Task<IEnumerable<Food>> GetAllFoodsByCategory(string category);
        Task<Food> GetFoodById(int id);
        Task<bool> CreateFood(Food food);
        Task<bool> UpdateFood(Food food);
        Task<bool> DeleteFood(Food food);
    }
}
