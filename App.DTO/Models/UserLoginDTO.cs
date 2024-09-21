using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models
{
    public class UserLoginDTO
    {
        public string Idnumber { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
