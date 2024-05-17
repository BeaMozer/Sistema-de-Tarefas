using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_Myte_Grupo3.Data;
using ProjetoFinal_Myte_Grupo3.Models;

namespace ProjetoFinal_Myte_Grupo3.Controllers
{
    public class RegistersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Register.Include(r => r.Employee).Include(r => r.WBS);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .Include(r => r.Employee)
                .Include(r => r.WBS)
                .FirstOrDefaultAsync(m => m.RegisterId == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email");
            ViewData["WBSId"] = new SelectList(_context.WBS, "WBSId", "Code");
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterId,EmployeeId,WBSId,WorkHours,DayOfWeek")] Register register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(register);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception (or handle it as necessary)
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }

            // If we got this far, something failed; redisplay the form
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email", register.EmployeeId);
            ViewData["WBSId"] = new SelectList(_context.WBS, "WBSId", "Code", register.WBSId);
            return View(register);
        }


        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email", register.EmployeeId);
            ViewData["WBSId"] = new SelectList(_context.WBS, "WBSId", "Code", register.WBSId);
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegisterId,EmployeeId,WBSId,WorkHours,DayOfWeek")] Register register)
        {
            if (id != register.RegisterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.RegisterId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "Email", register.EmployeeId);
            ViewData["WBSId"] = new SelectList(_context.WBS, "WBSId", "Code", register.WBSId);
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .Include(r => r.Employee)
                .Include(r => r.WBS)
                .FirstOrDefaultAsync(m => m.RegisterId == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.Register.FindAsync(id);
            if (register != null)
            {
                _context.Register.Remove(register);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.RegisterId == id);
        }
    }
}
