using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Repository
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllFoods();
        Task<IEnumerable<Food>> GetAllFoodsByCategory(string category);
        Task<Food> GetById(int id);
        bool Create(Food food);    
        bool Update(Food food);
        bool Delete(Food food);
        bool Save();

    }
}
