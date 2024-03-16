using AucklandTalyer.Data;
using AucklandTalyer.Models;
using AucklandTalyer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ApplicationDbContext _db;

        public CustomerController(ICustomerRepository customerRepository, ApplicationDbContext db)
        {
            _customerRepository = customerRepository;   
            _db = db;
        }
        public IActionResult Index()
        {
            var customerList = _customerRepository.GetAll();
            return View(customerList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarRego", "CustomerName", "CarMake", "CarModel", "PaymentStatus")] tblCustomer customer)
        {
            if(ModelState.IsValid)
            {
                customer.DateAdded = DateTime.Now;
                customer.AddedBy = "Admin";
                _db.tblCustomer.Add(customer);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
       //public async Task<IActionResult> Create([Bind("CustomerName", "CarMake", "CarModel", "CarRego")]tblCustomer customer)
       // {
       //     tblIssue issue = new tblIssue();

       //     if(ModelState.IsValid)
       //     {
       //         customer.DateAdded = DateTime.Now;
       //         customer.AddedBy = "Admin";
       //         _db.Add(customer);
       //         await _db.SaveChangesAsync();
       //         var getCustomerId = _customerRepository.GetCustomerId();
       //         issue.CustomerId = getCustomerId.CustomerId;
       //         _db.Add(issue);
       //         await _db.SaveChangesAsync();
       //         return RedirectToAction("Index");
       //     }
       //     return View(customer);
       // }
    }

}
