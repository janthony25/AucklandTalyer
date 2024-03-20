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

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var targetParts = _db.tblParts.FirstOrDefault(x => x.PartsId == id);
            return View(targetParts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PartsName", "PartsPrice")] tblParts parts)
        {
            if(ModelState.IsValid)
            {
                parts.DateAdded = DateTime.Now;
                parts.AddedBy = "Admin";
                _db.tblParts.Update(parts);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parts);
        }
    }
}
