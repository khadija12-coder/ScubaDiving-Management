#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppScubaDiving.Data;
using AppScubaDiving.Models;

namespace AppScubaDiving.Controllers
{
    public class MaterielPlongeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterielPlongeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaterielPlongees
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterielPlongee.ToListAsync());
        }

        // GET: MaterielPlongees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materielPlongee = await _context.MaterielPlongee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materielPlongee == null)
            {
                return NotFound();
            }

            return View(materielPlongee);
        }

        // GET: MaterielPlongees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterielPlongees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomMateriel,Poids,Prix")] MaterielPlongee materielPlongee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materielPlongee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materielPlongee);
        }

        // GET: MaterielPlongees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materielPlongee = await _context.MaterielPlongee.FindAsync(id);
            if (materielPlongee == null)
            {
                return NotFound();
            }
            return View(materielPlongee);
        }

        // POST: MaterielPlongees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomMateriel,Poids,Prix")] MaterielPlongee materielPlongee)
        {
            if (id != materielPlongee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materielPlongee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterielPlongeeExists(materielPlongee.Id))
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
            return View(materielPlongee);
        }

        // GET: MaterielPlongees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materielPlongee = await _context.MaterielPlongee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materielPlongee == null)
            {
                return NotFound();
            }

            return View(materielPlongee);
        }

        // POST: MaterielPlongees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materielPlongee = await _context.MaterielPlongee.FindAsync(id);
            _context.MaterielPlongee.Remove(materielPlongee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterielPlongeeExists(int id)
        {
            return _context.MaterielPlongee.Any(e => e.Id == id);
        }
    }
}
