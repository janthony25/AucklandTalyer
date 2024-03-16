namespace AucklandTalyer.Models.Dto
{
    public class CustomerListDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public float? TotalPrice { get; set; }
        public string? PaymentStatus { get; set; }
        public string? WorkStatus { get; set; }

    }
}
