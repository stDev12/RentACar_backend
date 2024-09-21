using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models
{
    public class ExtraDTO
    {
        public int ExtraId { get; set; }

        public string ExtraName { get; set; } = null!;

        public decimal Price { get; set; }

/*        public virtual ICollection<ShoppingCart> CartItems { get; set; } = new List<ShoppingCart>();

        public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
*/
    }
}
