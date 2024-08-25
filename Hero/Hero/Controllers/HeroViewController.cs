using hero_csharp.Data;
using hero_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hero_csharp.Controllers
{
    public class HeroController : Controller
    {
        private readonly DataContext _context;

        public HeroController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var heroes = await _context.Heroes.ToListAsync();
            return View(heroes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hero);
        }

        public async Task<IActionResult> Details(int id)
        {
            var hero = await _context.Heroes.FirstOrDefaultAsync(m => m.Id == id);
            if (hero == null)
            {
                return NotFound();
            }
            return View(hero);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return View(hero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hero hero)
        {
            if (id != hero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Heroes.Any(e => e.Id == id))
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
            return View(hero);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return View(hero);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}