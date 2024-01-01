namespace ShopOnlineCafe.Server.Authentication.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserAccount>> GetAllUsers();
        
        UserAccount? GetUserAccountByEmail(string email);
        bool Create(UserAccount userAccount);
        bool Save();


    }
}
