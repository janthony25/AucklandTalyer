using AucklandTalyer.Data;
using AucklandTalyer.Models;
using AucklandTalyer.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AucklandTalyer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        
        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<tblCustomer> GetAll()
        {
            var customerList = _db.tblCustomer.ToList(); 
            return customerList;
        }

        public List<CustomerIssueDto> GetIssue(string Rego)
        {
            //var customerIssue = _db.tblCustomer.Join(_db.tblIssue, TC => TC.CarRego, TI => TI.CarRego,
            //    (TC, TI) => new
            //    {
            //        CarRego = TC.CarRego,
            //        CustomerName = TC.CustomerName,
            //        CarMake = TC.CarMake,
            //        CarModel = TC.CarModel,
            //        PayMentStatus = TC.PaymentStatus,
            //        Issue = TI.IssueName,
            //        IssueDescription = TI.IssueDescription
            //    }).Where(p => p.CarRego == Rego)
            //    .Select(x => new CustomerIssueDto()
            //    {
            //        CarRego = x.CarRego,
            //        CustomerName = x.CustomerName,
            //        CarMake = x.CarMake,
            //        CarModel = x.CarModel,
            //        PaymentStatus = x.PayMentStatus,
            //        IssueName = x.Issue,
            //        IssueDescription = x.IssueDescription
            //    }).ToList();

            //var custIssue = from issue in _db.tblIssue
            //                                   join customer in _db.tblCustomer
            //                                   on issue.CarRego equals customer.CarRego into joinedCustomers
            //                                   from joinedCustomer in joinedCustomers.DefaultIfEmpty()
            //                                   select new
            //                                   {
            //                                       Issue = issue,
            //                                       Customer = joinedCustomer
            //                                   };


            var leftJoinQuery = from customer in _db.tblCustomer
                                join issue in _db.tblIssue
                                on customer.CarRego equals issue.CarRego
                                into joinedCustomers
                                from joinedCustomer in joinedCustomers.DefaultIfEmpty()
                                 where customer.CarRego == Rego
                                select new
                                {
                                    CarRego = customer.CarRego,
                                    CustomerName = customer.CustomerName,
                                    CarMake = customer.CarMake,
                                    CarModel = customer.CarModel,
                                    PaymentStatus = customer.PaymentStatus,
                                    IssueName = joinedCustomer != null ? joinedCustomer.IssueName : "",
                                    IssueDescription = joinedCustomer != null ? joinedCustomer.IssueDescription : ""
                                };
           // var testing = leftJoinQuery.ToList();

            List<CustomerIssueDto> resultList = leftJoinQuery
                .AsEnumerable()
                .Select(x => new CustomerIssueDto
                {
                    CarRego = x.CarRego,
                    CustomerName = x.CustomerName,
                    CarMake = x.CarMake,
                    CarModel = x.CarModel,
                    PaymentStatus = x.PaymentStatus,
                    IssueName = x.IssueName,
                    IssueDescription = x.IssueDescription
                })
                .ToList();

              return resultList;

        }
        
        // RETRIEVE DATA FROM CustomerListDto
        //public List<CustomerListDto> GetCustomer()
        //{
        //    var customer = _db.tblCustomer.Join(_db.tblIssue, TC => TC.CustomerId, TI => TI.CustomerId,
        //                    (TC, TI) => new
        //                    {
        //                        customerId = TC.CustomerId,
        //                        customerName = TC.CustomerName,
        //                        totalPrice = TI.TotalPrice,
        //                        paymentStatus = TC.PaymentStatus,
        //                        workStatus = TC.WorkStatus
        //                    })
        //                    .Select(x => new CustomerListDto()
        //                    {
        //                        CustomerId = x.customerId,
        //                        CustomerName = x.customerName,
        //                        TotalPrice = x.totalPrice,
        //                        PaymentStatus = x.paymentStatus,
        //                        WorkStatus = x.workStatus
        //                    }).ToList();

        //    return customer;
        //}

        // GETTING MAX ID 
        //public tblCustomer GetCustomerId()
        //{
        //    var latestId = _db.tblCustomer.Max(x => x.CustomerId);
        //    return _db.tblCustomer.FirstOrDefault(y => y.CustomerId == latestId);
        //}
    }
}
