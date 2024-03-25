using AucklandTalyer.Models;
using AucklandTalyer.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace AucklandTalyer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<tblCustomer> tblCustomer { get; set; }
        public DbSet<tblIssue> tblIssue { get; set; }
        public DbSet<tblParts> tblParts { get; set; }
        public DbSet<tblIssueWithParts> tblIssueWithParts { get; set; }
    }
}
