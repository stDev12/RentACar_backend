using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models
{
    public class CartDTO
    {
        public int CartItemId { get; set; }

        public Guid UserId { get; set; }

        public int CarId { get; set; }

        public int Quantity { get; set; }

        public virtual CarDTO Car { get; set; } = null!;

        public virtual ICollection<ExtraDTO> Extras { get; set; } = new List<ExtraDTO>();
    }
}
