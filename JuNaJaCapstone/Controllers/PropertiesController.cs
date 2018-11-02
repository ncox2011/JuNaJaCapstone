using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuNaJaCapstone.Data;
using JuNaJaCapstone.Models;
using Microsoft.AspNetCore.Identity;

namespace JuNaJaCapstone.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public PropertiesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Property.Include(p => p.User).Include(p => p.Notes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = new PropertyDetailViewModel();

            viewModel.Property = await _context.Property
                .Include(p => p.User)
                .Include(p => p.Notes)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (viewModel.Property == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Properties/Create
        public  IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,Address,Description,Bedrooms,Bathrooms,Rent,Mortgage,Rented,DateSold")] Property property)
        {
            // Remove the user from the model validation because it is
            // not information posted in the form
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                IdentityUser user = await GetCurrentUserAsync();
                property.UserId = user.Id;
                _context.Add(property);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = property.PropertyId });
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", property.UserId);
            return View(property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Property.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", property.UserId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyId,Address,Description,Bedrooms,Bathrooms,Rent,Mortgage,Rented,UserId,DateSold")] Property @property)
        {
            if (id != property.PropertyId)
            {
                return NotFound();
            }
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                try
                {   
                    _context.Update(property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(property.PropertyId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", property.UserId);
            return View(property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.Property.FindAsync(id);
            _context.Property.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.PropertyId == id);
        }
    }
}
