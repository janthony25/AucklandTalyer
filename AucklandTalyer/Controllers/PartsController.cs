using AucklandTalyer.Data;
using AucklandTalyer.Models;
using AucklandTalyer.Models.Dto;
using AucklandTalyer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AucklandTalyer.Controllers
{
    public class PartsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICommonRepository _commonRepository;
        public PartsController(ApplicationDbContext db, ICommonRepository commonRepository)
        {
            _db = db;
            _commonRepository = commonRepository;
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

            if (targetParts == null)
            {
                return NotFound();
            }
            return View(targetParts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("PartsId","PartsName", "PartsPrice")] tblParts parts)
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

        // GET
        //public IActionResult Delete(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var targetId = _db.tblParts.FirstOrDefault(x => x.PartsId == id);

        //    if (targetId == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(targetId);
        //}

       
       

        public IActionResult DeletePost(int id)
        {
            var targetId = _db.tblParts.FirstOrDefault(x => x.PartsId == id);
            if (targetId == null)
            {
                return NotFound();
            }

            _db.tblParts.Remove(targetId);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET data in Parts Table 
        public IActionResult GetPartsData()
        {
            // Retrieve data from your data source (e.g., database)
            var data = _commonRepository.GetPartsData();
            var json = Json(data);
            // Return data as JSON
            return Json(data);
        }

        [HttpPost]
        public IActionResult AddPartsInIssue(List<tblIssueWithParts> selectedRows)
        {
            foreach (var parts in selectedRows)
            {
                var newRow = new tblIssueWithParts()
                {
                    IssueId = parts.IssueId,
                    PartsId = parts.PartsId,
                    DateAdded = DateTime.Now,
                    AddedBy = "Admin"
                };
                _db.tblIssueWithParts.Add(newRow);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Parts added successfully." });
        }   

    }
}
