namespace App.Api.Models
{
    public class UserUpdateRequest
    {
        public string Idnumber { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string UserPassword { get; set; } = null!;
    }
}
