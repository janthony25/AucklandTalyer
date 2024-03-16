using AucklandTalyer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;   
        }
        public IActionResult Index()
        {
            var customerList = _customerRepository.GetCustomer();
            return View(customerList);
        }
    }
}
