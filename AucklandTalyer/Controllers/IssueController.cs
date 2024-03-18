using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
