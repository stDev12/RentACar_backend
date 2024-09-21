namespace App.Api.Models
{
    public class CartRequest
    {
        public Guid UserId { get; set; }

        public int CarId { get; set; }
    }
}
