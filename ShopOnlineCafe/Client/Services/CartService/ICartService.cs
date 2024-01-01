using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(OrderProduct product); 
        Task<List<OrderProduct>> GetAll();
        Task ClearAll();
        Task DeleteItem(OrderProduct product);
        Task UpdateItem(List<OrderProduct> products);
        Task<decimal> GetSumOrders();
        Task<string> Checkout();

    }
}
