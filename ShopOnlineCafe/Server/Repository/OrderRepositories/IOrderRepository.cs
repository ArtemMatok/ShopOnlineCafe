using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Repository.OrderRepositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetByOrderId(int id);
        Task<int> GetOrderCount();
        Task<Order> GetOrderByKod(string kod);
        bool Add(Order order);
        bool Delete(Order order);
         Task<bool> UpdateIsDone(Order order);
        bool Save();
    }
}
