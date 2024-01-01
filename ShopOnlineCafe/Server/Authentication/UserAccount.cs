using System.ComponentModel.DataAnnotations;

namespace ShopOnlineCafe.Server.Authentication
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
