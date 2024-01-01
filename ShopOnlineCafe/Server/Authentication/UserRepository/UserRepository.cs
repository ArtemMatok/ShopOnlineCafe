using Microsoft.EntityFrameworkCore;
using ShopOnlineCafe.Server.Data;

namespace ShopOnlineCafe.Server.Authentication.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(UserAccount userAccount)
        {
            _context.Users.Add(userAccount);
            return Save();
        }



        public async Task<IEnumerable<UserAccount>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public UserAccount? GetUserAccountByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
