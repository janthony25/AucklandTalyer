using AucklandTalyer.Data;
using AucklandTalyer.Models.Dto;

namespace AucklandTalyer.Repository
{
    public class PartsIssueRepository : IPartsIssueRepository
    {
        private readonly ApplicationDbContext _db;
        public PartsIssueRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<IssueWithPartsDto> GetParts(int id)
        {
            var issueWithPartsQuery =   from parts in _db.tblParts
                                        join issueWithParts in _db.tblIssueWithParts
                                        on parts.PartsId equals issueWithParts.PartsId
                                        where issueWithParts.IssueId == id
                                        select new
                                        {
                                            PartsId = parts.PartsId,
                                            PartsName = parts.PartsName,
                                            PartsPrice = parts.PartsPrice,
                                        };
            // var testing = leftJoinQuery.ToList();

            List<IssueWithPartsDto> resultList = issueWithPartsQuery
                .AsEnumerable()
                .Select(x => new IssueWithPartsDto
                {
                    PartsId = x.PartsId,
                    PartsName = x.PartsName,
                    PartsPrice = x.PartsPrice,
                })
                .ToList();

            return resultList;

        }
    }
}
