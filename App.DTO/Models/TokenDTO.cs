using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models
{
    public class TokenDTO
    {
        public Guid TokenId { get; set; }

        public Guid UserId { get; set; }

        public string TokenJwt { get; set; } = null!;

        public DateTime ExpiryDate { get; set; }
    }
}
