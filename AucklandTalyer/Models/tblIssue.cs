using System.ComponentModel.DataAnnotations;

namespace AucklandTalyer.Models
{
    public class tblIssue
    {
        [Key]
        public int IssueId { get; set; }
        public string? IssueName { get; set; }
        public string? IssueDescription { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
        public string WorkStatus { get; set; }
        public string? CarRego { get; set; }

    }
}
