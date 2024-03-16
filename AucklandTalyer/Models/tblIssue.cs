namespace AucklandTalyer.Models
{
    public class tblIssue
    {
        public int IssueId { get; set; }
        public string IssueName { get; set; }
        public string IssueDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }

        public int CustomerId { get; set; }

    }
}
