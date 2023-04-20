﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HalloASPMVC.Data;
using HalloASPMVC.Models;

namespace HalloASPMVC.Controllers
{
    public class KundenController : Controller
    {
        private readonly HalloASPMVCContext _context;

        public KundenController(HalloASPMVCContext context)
        {
            _context = context;
        }

        // GET: Kunden
        public async Task<IActionResult> Index()
        {
              return _context.Kunde != null ? 
                          View(await _context.Kunde.ToListAsync()) :
                          Problem("Entity set 'HalloASPMVCContext.Kunde'  is null.");
        }

        // GET: Kunden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kunde == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunde
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // GET: Kunden/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kunden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,KdNummer,GebDatum")] Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kunde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kunde);
        }

        // GET: Kunden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kunde == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunde.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }
            return View(kunde);
        }

        // POST: Kunden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,KdNummer,GebDatum")] Kunde kunde)
        {
            if (id != kunde.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kunde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KundeExists(kunde.Id))
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
            return View(kunde);
        }

        // GET: Kunden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kunde == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunde
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // POST: Kunden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kunde == null)
            {
                return Problem("Entity set 'HalloASPMVCContext.Kunde'  is null.");
            }
            var kunde = await _context.Kunde.FindAsync(id);
            if (kunde != null)
            {
                _context.Kunde.Remove(kunde);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KundeExists(int id)
        {
          return (_context.Kunde?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
