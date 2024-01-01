using ShopOnlineCafe.Shared;
using System.Net.Http.Json;

namespace ShopOnlineCafe.Client.Services
{
    public class FoodService : IFoodService
    {
        private readonly HttpClient _httpClient;

        public FoodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Food> GetFoodById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Food>($"api/Food/GetProductById/{id}");
        }

        public async Task<bool> CreateFood(Food food)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Food/Create", food);
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> DeleteFood(Food food)
        {
            var resut = await _httpClient.DeleteAsync($"api/Food/Delete/{food.Id}");
            if(resut.IsSuccessStatusCode) { return true; }
            else { return false; }
        }

        public async Task<IEnumerable<Food>> GetAllFoods()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Food>>("api/Food/GetAllProducts");
        }

        public async Task<IEnumerable<Food>> GetAllFoodsByCategory(string category)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Food>>($"api/Food/GetAllProducts/{category}");

        }

        public async Task<bool> UpdateFood(Food food)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Food/Update/{food.Id}", food);
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            else { return false; }
                
        }
    }
}
