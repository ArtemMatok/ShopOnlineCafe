using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnlineCafe.Shared
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal SumOfProduct { get; set; }
    }
}
