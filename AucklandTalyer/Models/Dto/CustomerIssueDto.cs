namespace AucklandTalyer.Models.Dto
{
    public class CustomerIssueDto
    {
        public string? CarRego { get; set; }
        public string? CustomerName { get; set; }
        public string? CarModel { get; set; }
        public string? CarMake { get; set; }

        public string? PaymentStatus { get; set; }
        public int IssueId { get; set; }

        public string? IssueName { get; set; }
        public string? IssueDescription { get; set; }
    }
}
