using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ShopOnlineCafe.Shared;
using System.Net.Http.Json;

namespace ShopOnlineCafe.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localService;
        private readonly IFoodService _foodService;
        private readonly NavigationManager _navManager;
        private readonly HttpClient _httpClient;
        public CartService(ILocalStorageService localService, IFoodService foodService, NavigationManager navManager, HttpClient httpClient)
        {
            _localService = localService;
            _foodService = foodService;
            _navManager = navManager;
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public async Task AddToCart(OrderProduct productVariant)
        {
            var cart = await _localService.GetItemAsync<List<OrderProduct>>("cart");
            if (cart == null)
            {
                cart = new List<OrderProduct>();
            }
            cart.Add(productVariant);
            await _localService.SetItemAsync("cart", cart);

            OnChange.Invoke();
        }

        public async Task<string> Checkout()
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payment/Checkout", await GetAll());
            var url = await result.Content.ReadAsStringAsync();
            return url;
        }

        public async Task ClearAll()
        {
            var cart = await _localService.GetItemAsync<List<OrderProduct>>("cart");
            cart.Clear();
            await _localService.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task DeleteItem(OrderProduct product)
        {
            var cart =await  _localService.GetItemAsync<List<OrderProduct>>("cart");
            if(cart is null)
            {
                return;
            }
            var cartItem = cart.Find(x => x.Food.Id == product.Food.Id);
            cart.Remove(cartItem);

            await _localService.SetItemAsync("cart",cart);
            OnChange.Invoke();

        }

        public async Task<List<OrderProduct>> GetAll()
        {
            var result = await _localService.GetItemAsync<List<OrderProduct>>("cart");
            
            if(result == null)
            {
                return new List<OrderProduct> ();  
            }
            else
            {
                return result;  
            }
        }

        public async Task<decimal> GetSumOrders()
        {
            var cart = await _localService.GetItemAsync<List<OrderProduct>>("cart");
            var sum = cart.Sum(x => (x.Food.Price*x.Quantity));
            OnChange.Invoke();
            return sum;
        }

        public async Task UpdateItem(List<OrderProduct> products)
        {
            var cart = products.ToList();
            await _localService.SetItemAsync("cart", cart);
            OnChange.Invoke();
            _navManager.NavigateTo("/checkout");
        }
    }
}
