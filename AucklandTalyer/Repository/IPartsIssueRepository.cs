using AucklandTalyer.Models.Dto;

namespace AucklandTalyer.Repository
{
    public interface IPartsIssueRepository
    {
        public List<IssueWithPartsDto> GetPartsInIssue(int id);
    }
}
