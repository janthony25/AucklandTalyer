﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AucklandTalyer.Models
{
    public class tblCustomer
    {
        [Key]
        public string CarRego { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public DateTime DateAdded { get; set; }
        public string? AddedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
        public string? PaymentStatus { get; set; }

      //  public List<tblIssue>? Issues { get; set; }
    }
}
