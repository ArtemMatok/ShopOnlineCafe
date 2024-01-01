using Microsoft.AspNetCore.Components;
using ShopOnlineCafe.Shared;
using System.Net.Http.Json;

namespace ShopOnlineCafe.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           
        }

        
        public async Task<bool> CreateOrder(Order order)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Order/Create", order);
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            var result = await _httpClient.DeleteAsync($"api/Order/Delete/{order.Id}");
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>("api/Order/GetAllOrders");
        }

        public async Task<Order> GetOrderByKod(string kod)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"api/Order/GetOrderByKod/{kod}");
        }

        public async Task<int> GetOrderCount()
        {
           return await _httpClient.GetFromJsonAsync<int>("api/Order/GetOrderCount");
            
        }

        public async Task<bool> UpdateIsDone(Order order)
        {
            var res =  await _httpClient.PutAsJsonAsync("api/Order/UpdateIsDone",order);
            if(res.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
