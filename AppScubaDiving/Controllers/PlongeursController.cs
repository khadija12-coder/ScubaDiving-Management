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
    public class PlongeursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlongeursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plongeurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plongeur.ToListAsync());
        }

        // GET: Plongeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plongeur = await _context.Plongeur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plongeur == null)
            {
                return NotFound();
            }

            return View(plongeur);
        }

        // GET: Plongeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plongeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Gmail,Age,Telephone")] Plongeur plongeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plongeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plongeur);
        }

        // GET: Plongeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plongeur = await _context.Plongeur.FindAsync(id);
            if (plongeur == null)
            {
                return NotFound();
            }
            return View(plongeur);
        }

        // POST: Plongeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Gmail,Age,Telephone")] Plongeur plongeur)
        {
            if (id != plongeur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plongeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlongeurExists(plongeur.Id))
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
            return View(plongeur);
        }

        // GET: Plongeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plongeur = await _context.Plongeur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plongeur == null)
            {
                return NotFound();
            }

            return View(plongeur);
        }

        // POST: Plongeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plongeur = await _context.Plongeur.FindAsync(id);
            _context.Plongeur.Remove(plongeur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlongeurExists(int id)
        {
            return _context.Plongeur.Any(e => e.Id == id);
        }
    }
}
