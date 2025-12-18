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
    public class DireccionClientesController : Controller
    {
        private readonly ChocoFreseoDbContext _context;

        public DireccionClientesController(ChocoFreseoDbContext context)
        {
            _context = context;
        }

        // GET: DireccionClientes
        public async Task<IActionResult> Index()
        {
            var chocoFreseoDbContext = _context.DireccionesCliente.Include(d => d.Cliente);
            return View(await chocoFreseoDbContext.ToListAsync());
        }

        // GET: DireccionClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCliente = await _context.DireccionesCliente
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionCliente == null)
            {
                return NotFound();
            }

            return View(direccionCliente);
        }

        // GET: DireccionClientes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");
            return View();
        }

        // POST: DireccionClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Barrio,Calle,Numero,Referencia,EsPrincipal,Latitud,Longitud")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccionCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", direccionCliente.ClienteId);
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCliente = await _context.DireccionesCliente.FindAsync(id);
            if (direccionCliente == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", direccionCliente.ClienteId);
            return View(direccionCliente);
        }

        // POST: DireccionClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,Barrio,Calle,Numero,Referencia,EsPrincipal,Latitud,Longitud")] DireccionCliente direccionCliente)
        {
            if (id != direccionCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccionCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionClienteExists(direccionCliente.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", direccionCliente.ClienteId);
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCliente = await _context.DireccionesCliente
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionCliente == null)
            {
                return NotFound();
            }

            return View(direccionCliente);
        }

        // POST: DireccionClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccionCliente = await _context.DireccionesCliente.FindAsync(id);
            if (direccionCliente != null)
            {
                _context.DireccionesCliente.Remove(direccionCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionClienteExists(int id)
        {
            return _context.DireccionesCliente.Any(e => e.Id == id);
        }
    }
}
