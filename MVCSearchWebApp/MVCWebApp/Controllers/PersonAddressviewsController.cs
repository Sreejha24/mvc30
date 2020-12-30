using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Data;
using MVCWebApp.Models.Views;

namespace MVCWebApp.Controllers
{
    public class PersonAddressviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonAddressviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonAddressviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonAddressview.ToListAsync());
        }

        //public IActionResult RawQuery(int id)
        //{
        //    var sql = "SELECT * FROM Person WHERE PersonID = {0}";

        //    var data = _context.Person.FromSqlRaw(sql, id).FirstOrDefault();

        //    return View(data);
        //}


        //public IActionResult RawQueryComplex(int id)
        //{
        //    IList<PersonAddressview> list = new List<PersonAddressview>();
        //    using (var conn = _context.Database.GetDbConnection())
        //    {
        //        conn.Open();
        //        using (var command = conn.CreateCommand())
        //        {
        //            var sql = "SELECT P.PersonID, P.FirstName, P.LastName, P.Email, P.Mobile, P.AddressID, A.AddressLine, A.City, A.Pin FROM People P, PAddress A " +
        //                " WHERE P.AddressID = A.AddressID";
        //            command.CommandText = sql;
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var record = new PersonAddressview()
        //                        {
        //                           PersonID = reader.GetInt32(0),
        //                           FirstName = reader.GetString(1),
        //                           LastName = reader.GetString(2),
        //                           Email = reader.GetString(3),
        //                           Mobile = reader.GetInt64(4),
        //                           AddressID = reader.GetInt32(5),
        //                           AddressLine = reader.GetString(6),
        //                           City = reader.GetString(7),
        //                           Pin = reader.GetInt32(8)
        //                        };
        //                        list.Add(record);
        //                    }
        //                }
        //            } // reader
        //        } // command
        //        conn.Close();
        //    } // connection

        //    return View(list);
        //}


        // GET: PersonAddressviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAddressview = await _context.PersonAddressview
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (personAddressview == null)
            {
                return NotFound();
            }

            return View(personAddressview);
        }

        // GET: PersonAddressviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonAddressviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,Email,Mobile,AddressId,AddressLine,City,Pin")] PersonAddressview personAddressview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personAddressview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personAddressview);
        }

        // GET: PersonAddressviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAddressview = await _context.PersonAddressview.FindAsync(id);
            if (personAddressview == null)
            {
                return NotFound();
            }
            return View(personAddressview);
        }

        // POST: PersonAddressviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,LastName,Email,Mobile,AddressId,AddressLine,City,Pin")] PersonAddressview personAddressview)
        {
            if (id != personAddressview.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personAddressview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonAddressviewExists(personAddressview.PersonID))
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
            return View(personAddressview);
        }

        // GET: PersonAddressviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAddressview = await _context.PersonAddressview
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (personAddressview == null)
            {
                return NotFound();
            }

            return View(personAddressview);
        }

        // POST: PersonAddressviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personAddressview = await _context.PersonAddressview.FindAsync(id);
            _context.PersonAddressview.Remove(personAddressview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonAddressviewExists(int id)
        {
            return _context.PersonAddressview.Any(e => e.PersonID == id);
        }
    }
}
