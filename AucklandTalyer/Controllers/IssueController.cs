using AucklandTalyer.Data;
using AucklandTalyer.Models;
using AucklandTalyer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICommonRepository _commonRepository;
        private readonly IPartsIssueRepository _partsIssueRepository;
        public IssueController(ApplicationDbContext db, ICommonRepository commonRepository, IPartsIssueRepository partsIssueRepository)
        {
            _db = db;
            _commonRepository = commonRepository;
            _partsIssueRepository = partsIssueRepository;
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

        public IActionResult GetIssuePartsData()
        {
            // Retrieve data from your data source (e.g., database)
            var data = _commonRepository.GetIssuePartsData();
            var json = Json(data);
            // Return data as JSON
            return Json(data);
        }

        public IActionResult GetPartsInIssue(int id)
        {
            var partWithIssue = _partsIssueRepository.GetPartsInIssue(id);
            return Json(partWithIssue);
        }


    }
}
