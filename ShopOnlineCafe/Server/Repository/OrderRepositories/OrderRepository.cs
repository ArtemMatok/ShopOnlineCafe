using Microsoft.EntityFrameworkCore;
using ShopOnlineCafe.Server.Data;
using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Repository.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Order order)
        {
            _context.Orders.Add(order);
            return Save();
        }

        public bool Delete(Order order)
        {
            _context.Orders.Remove(order);
            return Save();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
           
            return await _context.Orders.Include(x=>x.Orders).ToListAsync();
        }

        public async Task<Order> GetByOrderId(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> GetOrderByKod(string kod)
        {
            return await _context.Orders.Include(x=>x.Orders).FirstOrDefaultAsync(x => x.Kod == kod);
        }

        public async Task<int> GetOrderCount()
        {
            var res = await _context.Orders.ToListAsync();
            if(res.Count == 0)
            {
                return 1;
            }
            else
            {
                return res.Count();
            }
            
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateIsDone(Order order)
        {
            var orderUpdate = await GetByOrderId(order.Id);
            if(orderUpdate == null)
            {
                return false;
            }
            orderUpdate.IsDone = order.IsDone;
            _context.Orders.Update(orderUpdate);
            return Save();
        }
    }
}
