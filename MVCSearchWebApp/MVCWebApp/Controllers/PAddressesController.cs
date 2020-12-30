using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class PAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.PAddress.ToListAsync());
        }

        // GET: PAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pAddress = await _context.PAddress
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (pAddress == null)
            {
                return NotFound();
            }

            return View(pAddress);
        }

        // GET: PAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,AddressLine,City,Pin")] PAddress pAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pAddress);
        }

        // GET: PAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pAddress = await _context.PAddress.FindAsync(id);
            if (pAddress == null)
            {
                return NotFound();
            }
            return View(pAddress);
        }

        // POST: PAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,AddressLine,City,Pin")] PAddress pAddress)
        {
            if (id != pAddress.AddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PAddressExists(pAddress.AddressID))
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
            return View(pAddress);
        }

        // GET: PAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pAddress = await _context.PAddress
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (pAddress == null)
            {
                return NotFound();
            }

            return View(pAddress);
        }

        // POST: PAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pAddress = await _context.PAddress.FindAsync(id);
            _context.PAddress.Remove(pAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PAddressExists(int id)
        {
            return _context.PAddress.Any(e => e.AddressID == id);
        }
    }
}
