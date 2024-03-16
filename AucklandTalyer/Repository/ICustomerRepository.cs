using AucklandTalyer.Models.Dto;

namespace AucklandTalyer.Repository
{
    public interface ICustomerRepository
    {
        public List<CustomerListDto> GetCustomer();
    }
}
