using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnlineCafe.Shared
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<OrderList> Orders { get; set; } = new List<OrderList>();

        #region UserInfo
        [Required(ErrorMessage ="You should write your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should write your number")]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Incorrect Phone number")]
        public string PhoneNumber { get; set; }
        #endregion
        #region Delivery
        [Required(ErrorMessage ="You should write your address")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Select payment method")]
        public string Payment { get; set; }

        #endregion
        public string Kod { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
