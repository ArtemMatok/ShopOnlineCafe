using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Client.Services.UserService
{
    public interface IUserService
    {
        Task Authenticate(LoginRequest loginRequest);
        Task<bool> Register(RegisterRequest registerRequest);
    }
}
