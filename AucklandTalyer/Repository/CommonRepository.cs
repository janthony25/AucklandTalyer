using AucklandTalyer.Data;
using AucklandTalyer.Models;

namespace AucklandTalyer.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ApplicationDbContext _db;

        public CommonRepository(ApplicationDbContext db)
        {
            _db = db;   
        }
        public List<tblParts> GetPartsData()
        {
            var partsList = _db.tblParts.ToList();
            return partsList;
        }

        public List<tblIssueWithParts> GetIssuePartsData()
        {
            var issueWithPartsList = _db.tblIssueWithParts.ToList();
            return issueWithPartsList;
        }
    } 
}
