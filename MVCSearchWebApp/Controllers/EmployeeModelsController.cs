using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCSearchWebApp.Data;
using MVCSearchWebApp.Models;

namespace MVCSearchWebApp.Controllers
{
    public class EmployeeModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeModel.ToListAsync());
        }

        public IActionResult Search()
        {
            return View(new List<EmployeeModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(IFormCollection form)
        {
            var fieldName = form["FieldName"].ToString();
            var Keyword = form["Keyword"].ToString();
            IList<EmployeeModel> employeeModels = new List<EmployeeModel>();
            switch(fieldName)
            {
                case "EmployeeID":
                    var id = int.Parse(Keyword);
                    employeeModels = _context.EmployeeModel.Where(d => d.Equals(id)).ToList();
                    break;
                case "FirstName":
                    employeeModels = _context.EmployeeModel.Where(d => d.FirstName.StartsWith(Keyword)).OrderBy(d => d.FirstName).ToList();
                    break;
                case "LastName":
                    employeeModels = _context.EmployeeModel.Where(d => d.LastName.StartsWith(Keyword)).OrderBy(d => d.LastName).ToList();
                    break;
                case "Email":
                    employeeModels = _context.EmployeeModel.Where(d => d.Email.StartsWith(Keyword)).OrderBy(d => d.Email).ToList();
                    break;
                case "City":
                     employeeModels = _context.EmployeeModel.Where(d => d.City.StartsWith(Keyword)).OrderBy(d => d.City).ToList();
                    break;
                case "Mobile":
                    var mobile = long.Parse(Keyword);
                    employeeModels = _context.EmployeeModel.Where(d => d.Equals(mobile)).ToList();
                    break;
            }
            return View(employeeModels);
        }

        // GET: EmployeeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.EmployeeModel
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // GET: EmployeeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,LastName,Email,City,Mobile")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        // GET: EmployeeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.EmployeeModel.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        // POST: EmployeeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("EmployeeID,FirstName,LastName,Email,City,Mobile")] EmployeeModel employeeModel)
        {
            if (id != employeeModel.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeModelExists(employeeModel.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        // GET: EmployeeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.EmployeeModel
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // POST: EmployeeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var employeeModel = await _context.EmployeeModel.FindAsync(id);
            _context.EmployeeModel.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeModelExists(int? id)
        {
            return _context.EmployeeModel.Any(e => e.EmployeeID == id);
        }
    }
}
