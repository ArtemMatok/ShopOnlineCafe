using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnlineCafe.Shared
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="You shoud to write in this field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You shoud to write in this field")]
        [Range(0, 300000, ErrorMessage = "Values should to be greater than 0")]
        public decimal Price { get; set; }

        public string Image { get; set; }
        [Required(ErrorMessage = "You shoud to write in this field")]

        public string Category { get; set; }

        public string? Description { get; set; }
    }
}
