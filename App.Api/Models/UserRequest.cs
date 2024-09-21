namespace App.Api.Models
{
    public class UserRequest
    {
        public string UserName { get; set; } = null!;

        public string Idnumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string LicenseNumber { get; set; } = null!;

        public int Age { get; set; }

        public int RoleId { get; set; }
    }
}
