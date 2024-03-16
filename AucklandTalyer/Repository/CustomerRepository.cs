using AucklandTalyer.Data;
using AucklandTalyer.Models;
using AucklandTalyer.Models.Dto;

namespace AucklandTalyer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public List<CustomerListDto> GetCustomer()
        {
            var customer = _db.tblCustomer.Join(_db.tblIssue, TC => TC.CustomerId, TI => TI.CustomerId,
                            (TC, TI) => new
                            {
                                customerId = TC.CustomerId,
                                customerName = TC.CustomerName,
                                totalPrice = TI.TotalPrice,
                                paymentStatus = TC.PaymentStatus,
                                workStatus = TC.WorkStatus
                            })
                            .Select(x => new CustomerListDto()
                            {
                                CustomerId = x.customerId,
                                CustomerName = x.customerName,
                                TotalPrice = x.totalPrice,
                                PaymentStatus = x.paymentStatus,
                                WorkStatus = x.workStatus
                            }).ToList();

            return customer;
        }
    }
}
