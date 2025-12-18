using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChocoFreseo.Data;
using ChocoFreseo.Models.Domain;

namespace ChocoFreseo.Controllers
{
    public class ZonaEntregasController : Controller
    {
        private readonly ChocoFreseoDbContext _context;

        public ZonaEntregasController(ChocoFreseoDbContext context)
        {
            _context = context;
        }

        // GET: ZonaEntregas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZonasEntrega.ToListAsync());
        }

        // GET: ZonaEntregas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaEntrega = await _context.ZonasEntrega
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonaEntrega == null)
            {
                return NotFound();
            }

            return View(zonaEntrega);
        }

        // GET: ZonaEntregas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZonaEntregas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreZona,CostoDomicilioBase,TiempoEstimadoMinutos")] ZonaEntrega zonaEntrega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonaEntrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zonaEntrega);
        }

        // GET: ZonaEntregas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaEntrega = await _context.ZonasEntrega.FindAsync(id);
            if (zonaEntrega == null)
            {
                return NotFound();
            }
            return View(zonaEntrega);
        }

        // POST: ZonaEntregas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreZona,CostoDomicilioBase,TiempoEstimadoMinutos")] ZonaEntrega zonaEntrega)
        {
            if (id != zonaEntrega.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonaEntrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaEntregaExists(zonaEntrega.Id))
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
            return View(zonaEntrega);
        }

        // GET: ZonaEntregas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaEntrega = await _context.ZonasEntrega
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zonaEntrega == null)
            {
                return NotFound();
            }

            return View(zonaEntrega);
        }

        // POST: ZonaEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonaEntrega = await _context.ZonasEntrega.FindAsync(id);
            if (zonaEntrega != null)
            {
                _context.ZonasEntrega.Remove(zonaEntrega);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaEntregaExists(int id)
        {
            return _context.ZonasEntrega.Any(e => e.Id == id);
        }
    }
}
