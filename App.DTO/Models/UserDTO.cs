using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models
{
    public class UserDTO
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Idnumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string LicenseNumber { get; set; } = null!;

        public int Age { get; set; }

        public DateTime CreatedAt { get; set; }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<TokenDTO> Tokens { get; set; } = new List<TokenDTO>();
    }
}
