using AucklandTalyer.Data;
using AucklandTalyer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _db;
        public IssueController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string Rego)
        {
            
           // IEnumerable<tblCustomer> targetId = _db.tblCustomer.Where(c => c.CarRego == Rego).ToList();
            ViewBag.targetId = Rego;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IssueName", "IssueDescription", "WorkStatus", "CarRego")] tblIssue issue)
        {
            if (ModelState.IsValid)
            {
                issue.DateAdded = DateTime.Now;
                issue.AddedBy = "Admin";
                _db.tblIssue.Add(issue);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
