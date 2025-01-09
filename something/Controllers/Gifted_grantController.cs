using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using something.Models;

namespace something.Controllers
{
    public class Gifted_grantController : Controller
    {
        private readonly ApplicationContext _context;

        public Gifted_grantController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Gifted_grant
        public async Task<IActionResult> Index()
        {
            return View(await _context.gifted_grants.ToListAsync());
        }

        // GET: Gifted_grant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gifted_grant = await _context.gifted_grants
                .FirstOrDefaultAsync(m => m.id == id);
            if (gifted_grant == null)
            {
                return NotFound();
            }

            return View(gifted_grant);
        }

        // GET: Gifted_grant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gifted_grant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,student_id,grant_name,grant_value")] Gifted_grant gifted_grant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gifted_grant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gifted_grant);
        }

        // GET: Gifted_grant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gifted_grant = await _context.gifted_grants.FindAsync(id);
            if (gifted_grant == null)
            {
                return NotFound();
            }
            return View(gifted_grant);
        }

        // POST: Gifted_grant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,student_id,grant_name,grant_value")] Gifted_grant gifted_grant)
        {
            if (id != gifted_grant.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gifted_grant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Gifted_grantExists(gifted_grant.id))
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
            return View(gifted_grant);
        }

        // GET: Gifted_grant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gifted_grant = await _context.gifted_grants
                .FirstOrDefaultAsync(m => m.id == id);
            if (gifted_grant == null)
            {
                return NotFound();
            }

            return View(gifted_grant);
        }

        // POST: Gifted_grant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gifted_grant = await _context.gifted_grants.FindAsync(id);
            if (gifted_grant != null)
            {
                _context.gifted_grants.Remove(gifted_grant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Gifted_grantExists(int id)
        {
            return _context.gifted_grants.Any(e => e.id == id);
        }
    }
}
