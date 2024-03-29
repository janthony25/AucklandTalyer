﻿namespace AucklandTalyer.Models.Dto
{
    public class IssueWithPartsDto
    {
        public int? IssueWithPartsId { get; set; }
        public int? IssueId { get; set; }
        public int? PartsId { get; set; }
        public string? PartsName { get; set; }
        public decimal? PartsPrice { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}
