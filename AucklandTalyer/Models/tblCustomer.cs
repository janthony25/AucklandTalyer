using System.ComponentModel.DataAnnotations;

namespace AucklandTalyer.Models
{
    public class tblCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarRego { get; set; }
        public DateTime DateAdded { get; set; }
        public string? AddedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
