using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<int> GetOrderCount();
        Task<bool> CreateOrder(Order order);
        Task<bool> DeleteOrder(Order order);
        Task<Order> GetOrderByKod(string kod);
        Task<bool> UpdateIsDone(Order order);
   
    }
}
