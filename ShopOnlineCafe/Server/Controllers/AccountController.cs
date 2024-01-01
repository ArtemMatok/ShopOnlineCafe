using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnlineCafe.Server.Authentication;
using ShopOnlineCafe.Server.Authentication.UserRepository;
using ShopOnlineCafe.Shared;

namespace ShopOnlineCafe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public ActionResult<UserSession> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_userRepository);
            var userSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.Email, loginRequest.Password);
            if (userSession is null)
                return Unauthorized();
            else
                return userSession;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<UserAccount>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }


        [HttpPost("Register")]
        public async Task<ActionResult<RegisterRequest>>Register ([FromBody] RegisterRequest registerUser)
        {
            var email =  _userRepository.GetUserAccountByEmail(registerUser.Email);
            if(email is not null)
            {
                return BadRequest("Email is used");
            }
            UserAccount user = new UserAccount();
            user.Email = registerUser.Email;
            user.Password = registerUser.Password;
            user.Role = "User";
            _userRepository.Create(user);
            return Ok(user);

        }
        
    }

}
