using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taller1.Data;
using Taller1.Models;

namespace Taller1.Controllers
{
    public class VentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ====================================================
        // GET: Venta/Index
        // ====================================================
        public IActionResult Index()
        {
            var ventas = _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.VentaProductos)
                .ThenInclude(vp => vp.Producto)
                .ToList();

            return View(ventas);
        }

        // ====================================================
        // GET: Venta/Create
        // ====================================================
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            ViewBag.Productos = _context.Productos.ToList();
            return View();
        }

        // ====================================================
        // POST: Venta/Create
        // ====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta, List<VentaProducto> VentaProductos)
        {
            // Validar productos
            if (VentaProductos == null || !VentaProductos.Any(vp => vp.Cantidad > 0))
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto con cantidad mayor a 0.");
            }

            if (ModelState.IsValid)
            {
                decimal total = 0;

                foreach (var vp in VentaProductos)
                {
                    if (vp.Cantidad > 0)
                    {
                        total += vp.Cantidad * vp.PrecioUnitario;
                    }
                }

                venta.Total = total;
                venta.Fecha = venta.Fecha == default ? DateTime.Now : venta.Fecha;
                venta.VentaProductos = VentaProductos.Where(vp => vp.Cantidad > 0).ToList();

                _context.Ventas.Add(venta);
                _context.SaveChanges();

                // ✅ Redirige correctamente al Index
                return RedirectToAction(nameof(Index));
            }

            // Si falla, vuelve a mostrar el formulario con datos
            ViewBag.Clientes = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            ViewBag.Productos = _context.Productos.ToList();
            return View(venta);
        }

        // ====================================================
        // GET: Venta/Edit/{id}
        // ====================================================
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var venta = _context.Ventas
                .Include(v => v.VentaProductos)
                .FirstOrDefault(v => v.VentaId == id);

            if (venta == null) return NotFound();

            ViewBag.Clientes = new SelectList(_context.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            ViewBag.Productos = _context.Productos.ToList();
            return View(venta);
        }

        // ====================================================
        // POST: Venta/Edit
        // ====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venta venta, List<VentaProducto> VentaProductos)
        {
            if (ModelState.IsValid)
            {
                // Eliminar productos anteriores
                var anteriores = _context.VentaProductos.Where(vp => vp.VentaId == venta.VentaId);
                _context.VentaProductos.RemoveRange(anteriores);

                decimal total = 0;
                var nuevosVP = new List<VentaProducto>();

                foreach (var vp in VentaProductos)
                {
                    if (vp.Cantidad > 0)
                    {
                        nuevosVP.Add(new VentaProducto
                        {
                            VentaId = venta.VentaId,
                            ProductoId = vp.ProductoId,
                            Cantidad = vp.Cantidad,
                            PrecioUnitario = vp.PrecioUnitario
                        });

                        total += vp.Cantidad * vp.PrecioUnitario;
                    }
                }

                venta.Total = total;
                venta.Fecha = venta.Fecha == default ? DateTime.Now : venta.Fecha;

                _context.VentaProductos.AddRange(nuevosVP);
                _context.Ventas.Update(venta);
                _context.SaveChanges();

                // ✅ Redirige al Index tras guardar
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(_context.Clientes, "ClienteId", "Nombre", venta.ClienteId);
            ViewBag.Productos = _context.Productos.ToList();
            return View(venta);
        }

        // ====================================================
        // GET: Venta/Delete/{id}
        // ====================================================
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var venta = _context.Ventas
                .Include(v => v.Cliente)
                .FirstOrDefault(v => v.VentaId == id);

            if (venta == null) return NotFound();

            return View(venta);
        }

        // ====================================================
        // POST: Venta/DeleteConfirmed
        // ====================================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var venta = _context.Ventas
                .Include(v => v.VentaProductos)
                .FirstOrDefault(v => v.VentaId == id);

            if (venta == null) return NotFound();

            _context.VentaProductos.RemoveRange(venta.VentaProductos);
            _context.Ventas.Remove(venta);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
