using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuNaJaCapstone.Data;
using JuNaJaCapstone.Models;

namespace JuNaJaCapstone.Controllers
{
    public class PropertyNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PropertyNotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PropertyNote.Include(p => p.Property);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PropertyNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyNote = await _context.PropertyNote
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (propertyNote == null)
            {
                return NotFound();
            }

            return View(propertyNote);
        }

        // GET: PropertyNotes/Create
        public IActionResult Create()
        {
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId");
            return View();
        }

        // POST: PropertyNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoteId,NoteText,DateNoted,PropertyId")] PropertyNote propertyNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId", propertyNote.PropertyId);
            return View(propertyNote);
        }

        // GET: PropertyNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyNote = await _context.PropertyNote.FindAsync(id);
            if (propertyNote == null)
            {
                return NotFound();
            }
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId", propertyNote.PropertyId);
            return View(propertyNote);
        }

        // POST: PropertyNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoteId,NoteText,DateNoted,PropertyId")] PropertyNote propertyNote)
        {
            if (id != propertyNote.NoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyNoteExists(propertyNote.NoteId))
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
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId", propertyNote.PropertyId);
            return View(propertyNote);
        }

        // GET: PropertyNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyNote = await _context.PropertyNote
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (propertyNote == null)
            {
                return NotFound();
            }

            return View(propertyNote);
        }

        // POST: PropertyNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyNote = await _context.PropertyNote.FindAsync(id);
            _context.PropertyNote.Remove(propertyNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyNoteExists(int id)
        {
            return _context.PropertyNote.Any(e => e.NoteId == id);
        }
    }
}
