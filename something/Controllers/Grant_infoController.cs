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
    public class Grant_infoController : Controller
    {
        private readonly ApplicationContext _context;

        public Grant_infoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Grant_info
        public async Task<IActionResult> Index()
        {
            return View(await _context.grants_info.ToListAsync());
        }

        // GET: Grant_info/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grant_info = await _context.grants_info
                .FirstOrDefaultAsync(m => m.grant_name == id);
            if (grant_info == null)
            {
                return NotFound();
            }

            return View(grant_info);
        }

        // GET: Grant_info/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grant_info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("grant_name,banch_grant_value,master_grant_value,aspirant_grant_value")] Grant_info grant_info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grant_info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grant_info);
        }

        // GET: Grant_info/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grant_info = await _context.grants_info.FindAsync(id);
            if (grant_info == null)
            {
                return NotFound();
            }
            return View(grant_info);
        }

        // POST: Grant_info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("grant_name,banch_grant_value,master_grant_value,aspirant_grant_value")] Grant_info grant_info)
        {
            if (id != grant_info.grant_name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grant_info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Grant_infoExists(grant_info.grant_name))
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
            return View(grant_info);
        }

        // GET: Grant_info/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grant_info = await _context.grants_info
                .FirstOrDefaultAsync(m => m.grant_name == id);
            if (grant_info == null)
            {
                return NotFound();
            }

            return View(grant_info);
        }

        // POST: Grant_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var grant_info = await _context.grants_info.FindAsync(id);
            if (grant_info != null)
            {
                _context.grants_info.Remove(grant_info);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Grant_infoExists(string id)
        {
            return _context.grants_info.Any(e => e.grant_name == id);
        }
    }
}
