using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
