using System.ComponentModel.DataAnnotations;

namespace AucklandTalyer.Models
{
    public class tblParts
    {
        [Key]
        public int PartsId { get; set; }
        [Required]
        public string PartsName { get; set; }
        public decimal? PartsPrice { get; set; }
        public DateTime DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}
