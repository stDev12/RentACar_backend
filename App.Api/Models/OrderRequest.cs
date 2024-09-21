namespace App.Api.Models
{
    public class OrderRequest
    {
        public DateTime OrderDate { get; set; }

        public Guid UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual ICollection<RentalRequest> Rentals { get; set; } = new List<RentalRequest>();

    }
}
