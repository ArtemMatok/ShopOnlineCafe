using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnlineCafe.Shared
{
    public class OrderList
    {
        public int Id { get; set; }
        public string NameFood { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Sum => Price * Quantity;
    }
}
