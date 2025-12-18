using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechNova.Models;

namespace TechNova.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class VentasController : Controller
    {
        private readonly TechNovaContext _context;

        public VentasController(TechNovaContext context)
        {
            _context = context;
        }

        // GET: Ventas (CON BUSCADOR)
        public async Task<IActionResult> Index(string searchCliente, DateTime? searchFecha)
        {
            ViewData["CurrentFilterCliente"] = searchCliente;
            ViewData["CurrentFilterFecha"] = searchFecha?.ToString("yyyy-MM-dd");

            var ventas = _context.Ventas.Include(v => v.Cliente).AsQueryable();

            if (!string.IsNullOrEmpty(searchCliente))
            {
                ventas = ventas.Where(v => v.Cliente.Nombre.Contains(searchCliente));
            }

            if (searchFecha.HasValue)
            {
                ventas = ventas.Where(v => v.FechaVenta.Date == searchFecha.Value.Date);
            }

            return View(await ventas.ToListAsync());
        }

        // GET: Ventas/Details/5 (CON DESGLOSE COMPLETO)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (venta == null)
                return NotFound();

            ViewBag.Total = venta.DetalleVenta.Sum(d => d.Cantidad * d.PrecioUnitario);
            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            ViewData["Productos"] = new SelectList(_context.Productos.Where(p => p.Stock > 0), "ProductoId", "Nombre");
            return View();
        }

        // POST: Ventas/Create (CON VALIDACIÓN Y ACTUALIZACIÓN DE STOCK)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ClienteId, int[] ProductoIds, int[] Cantidades)
        {
            if (ProductoIds == null || Cantidades == null || ProductoIds.Length == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto");
                ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ClienteId);
                ViewData["Productos"] = new SelectList(_context.Productos.Where(p => p.Stock > 0), "ProductoId", "Nombre");
                return View();
            }

            // Validar stock
            for (int i = 0; i < ProductoIds.Length; i++)
            {
                var producto = await _context.Productos.FindAsync(ProductoIds[i]);
                if (producto == null)
                {
                    ModelState.AddModelError("", $"Producto no encontrado");
                    return View();
                }

                if (producto.Stock < Cantidades[i])
                {
                    ModelState.AddModelError("", $"Stock insuficiente para {producto.Nombre}. Solo hay {producto.Stock} unidades disponibles");
                    ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ClienteId);
                    ViewData["Productos"] = new SelectList(_context.Productos.Where(p => p.Stock > 0), "ProductoId", "Nombre");
                    return View();
                }
            }

            // Crear la venta
            var venta = new Venta
            {
                ClienteId = ClienteId,
                FechaVenta = DateTime.Now
            };
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            // Crear detalle y actualizar stock
            for (int i = 0; i < ProductoIds.Length; i++)
            {
                var producto = await _context.Productos.FindAsync(ProductoIds[i]);

                var detalle = new DetalleVenta
                {
                    VentaId = venta.VentaId,
                    ProductoId = producto.ProductoId,
                    Cantidad = Cantidades[i],
                    PrecioUnitario = producto.Precio
                };
                _context.DetalleVentas.Add(detalle);

                producto.Stock -= Cantidades[i];
                _context.Update(producto);
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Venta registrada exitosamente y stock actualizado";
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }
    }
}
