using AucklandTalyer.Models;
using AucklandTalyer.Models.Dto;

namespace AucklandTalyer.Repository
{
    public interface ICustomerRepository
    {
        // public List<CustomerListDto> GetCustomer();
        public List<tblCustomer> GetAll();
        //public tblCustomer GetCustomerId();
    }
}
