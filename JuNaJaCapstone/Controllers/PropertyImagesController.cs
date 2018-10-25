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
    public class PropertyImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PropertyImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PropertyImage.Include(p => p.Property);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PropertyImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyImage = await _context.PropertyImage
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (propertyImage == null)
            {
                return NotFound();
            }

            return View(propertyImage);
        }

        // GET: PropertyImages/Create
        public IActionResult Create()
        {
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId");
            return View();
        }

        // POST: PropertyImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,ImgURL,PropertyId")] PropertyImage propertyImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId", propertyImage.PropertyId);
            return View(propertyImage);
        }

        // GET: PropertyImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyImage = await _context.PropertyImage.FindAsync(id);
            if (propertyImage == null)
            {
                return NotFound();
            }
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId", propertyImage.PropertyId);
            return View(propertyImage);
        }

        // POST: PropertyImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,ImgURL,PropertyId")] PropertyImage propertyImage)
        {
            if (id != propertyImage.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyImageExists(propertyImage.ImageId))
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
            ViewData["PropertyId"] = new SelectList(_context.Property, "PropertyId", "UserId", propertyImage.PropertyId);
            return View(propertyImage);
        }

        // GET: PropertyImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyImage = await _context.PropertyImage
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (propertyImage == null)
            {
                return NotFound();
            }

            return View(propertyImage);
        }

        // POST: PropertyImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyImage = await _context.PropertyImage.FindAsync(id);
            _context.PropertyImage.Remove(propertyImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyImageExists(int id)
        {
            return _context.PropertyImage.Any(e => e.ImageId == id);
        }
    }
}
