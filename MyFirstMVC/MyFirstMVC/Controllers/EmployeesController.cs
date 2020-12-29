﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstMVC.Data;
using MyFirstMVC.Models;


namespace MyFirstMVC.Controllers
{
    public class EmployeesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

       public JsonResult GetResult(string searchBy,string searchValue)
        {
            List<Employee> empDetails = new List<Employee>();
            if(searchBy == "EmpId")
            {
                int id = Convert.ToInt32(searchValue);
                empDetails = _context.Employee.Where(e => e.EmpId == id || searchValue == null).ToList();
                return Json(empDetails);

            }else if(searchBy == "EmpName")
            {
                empDetails = _context.Employee.Where(e => e.EmpName.StartsWith(searchValue) || searchValue == null).ToList();
                return Json(empDetails);
            }
            else if(searchBy == "EmpSalary")
            {
                decimal salary = Convert.ToDecimal(searchValue);
                empDetails = _context.Employee.Where(e => e.EmpSalary == salary || searchValue == null).ToList();
                return Json(empDetails);
            }
            else if(searchBy == "city")
            {
                empDetails = _context.Employee.Where(e => e.city.StartsWith(searchValue) || searchValue == null).ToList();
                return Json(empDetails);
            }
            else
            {
                var emp = _context.Employee;
                return Json(emp);
            }
        }

       

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string EmpSearch)
        {
            var empquery = from x in _context.Employee select x;
            if (!string.IsNullOrEmpty(EmpSearch))
            {
                empquery = empquery.Where(x =>x.EmpName.Contains(EmpSearch));
            }
            return View(await empquery.AsNoTracking().ToListAsync());
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,EmpSalary,city,NetSalary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpName,EmpSalary,city,NetSalary")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
    }
}