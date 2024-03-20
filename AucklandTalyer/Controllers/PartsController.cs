using AucklandTalyer.Data;
using AucklandTalyer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class PartsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PartsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var parts = _db.tblParts.ToList();
            return View(parts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartsName", "PartsPrice")]tblParts parts)
        {
            if(ModelState.IsValid)
            {
                parts.DateAdded = DateTime.Now;
                parts.AddedBy = "Admin";
                _db.tblParts.Add(parts);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
