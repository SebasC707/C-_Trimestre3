using ChocoFreseo.Data;
using ChocoFreseo.Models.Domain;
using ChocoFreseo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ChocoFreseo.Controllers
{
    public class DomiciliosController : Controller
    {
        private readonly ChocoFreseoDbContext _context;

        public DomiciliosController(ChocoFreseoDbContext context)
        {
            _context = context;
        }

        // -------------------------------------------------------
        // LISTADO
        // -------------------------------------------------------
        // GET: Domicilios
        public async Task<IActionResult> Index()
        {
            var domicilios = await _context.Domicilios
                .Include(d => d.Pedido)
                    .ThenInclude(p => p.Cliente)
                .Include(d => d.DireccionCliente)
                .Include(d => d.ZonaEntrega)
                .Include(d => d.Repartidor)
                .ToListAsync();

            return View(domicilios);
        }

        // -------------------------------------------------------
        // DETALLE
        // -------------------------------------------------------
        // GET: Domicilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var domicilio = await _context.Domicilios
                .Include(d => d.Pedido)
                    .ThenInclude(p => p.Cliente)
                .Include(d => d.DireccionCliente)
                .Include(d => d.ZonaEntrega)
                .Include(d => d.Repartidor)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (domicilio == null)
                return NotFound();

            return View(domicilio);
        }

        // -------------------------------------------------------
        // CREAR
        // -------------------------------------------------------
        // GET: Domicilios/Create?pedidoId=5
        public async Task<IActionResult> Create(int? pedidoId)
        {
            if (pedidoId == null)
            {
                return BadRequest("Debe seleccionar un pedido para crear un domicilio.");
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == pedidoId.Value);

            if (pedido == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            // Direcciones del cliente
            var direcciones = await _context.DireccionesCliente
                .Where(d => d.ClienteId == pedido.ClienteId)
                .ToListAsync();

            // Zonas de entrega
            var zonas = await _context.ZonasEntrega.ToListAsync();

            // ViewModel para el formulario
            var vm = new DomicilioCreateViewModel
            {
                PedidoId = pedido.Id,
                Pedido = pedido,
                Cliente = pedido.Cliente,
                CostoDomicilio = 0m, // luego el usuario puede ajustarlo
                DireccionesCliente = direcciones
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = $"{d.Barrio} - {d.Calle} {d.Numero}"
                    }).ToList(),
                ZonasEntrega = zonas
                    .Select(z => new SelectListItem
                    {
                        Value = z.Id.ToString(),
                        Text = $"{z.NombreZona} (${z.CostoDomicilioBase})"
                    }).ToList(),
                Repartidores = await _context.Repartidores
                    .Where(r => r.Activo)
                    .Select(r => new SelectListItem
                    {
                        Value = r.Id.ToString(),
                        Text = r.NombreCompleto
                    }).ToListAsync()
            };

            // 🔹 Datos avanzados para el mapa y tiempo estimado (usados en la vista)
            ViewBag.DireccionesCoordsJson = JsonSerializer.Serialize(
                direcciones.Select(d => new
                {
                    id = d.Id,
                    lat = d.Latitud,   // pueden ser null, la vista lo maneja
                    lng = d.Longitud,
                    texto = $"{d.Barrio} - {d.Calle} {d.Numero}"
                })
            );

            ViewBag.ZonasDatosJson = JsonSerializer.Serialize(
                zonas.Select(z => new
                {
                    id = z.Id,
                    nombre = z.NombreZona,
                    minutos = z.TiempoEstimadoMinutos
                })
            );

            return View(vm);
        }

        // POST: Domicilios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DomicilioCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Zonas
                var zonas = await _context.ZonasEntrega.ToListAsync();
                model.ZonasEntrega = zonas
                    .Select(z => new SelectListItem
                    {
                        Value = z.Id.ToString(),
                        Text = $"{z.NombreZona} (${z.CostoDomicilioBase})"
                    }).ToList();

                // Pedido + cliente + direcciones
                if (model.PedidoId.HasValue)
                {
                    var pedido = await _context.Pedidos
                        .Include(p => p.Cliente)
                        .FirstOrDefaultAsync(p => p.Id == model.PedidoId.Value);

                    if (pedido != null)
                    {
                        model.Pedido = pedido;
                        model.Cliente = pedido.Cliente;

                        var direcciones = await _context.DireccionesCliente
                            .Where(d => d.ClienteId == pedido.ClienteId)
                            .ToListAsync();

                        model.DireccionesCliente = direcciones
                            .Select(d => new SelectListItem
                            {
                                Value = d.Id.ToString(),
                                Text = $"{d.Barrio} - {d.Calle} {d.Numero}"
                            }).ToList();

                        // ViewBag para mapa (mismo formato que en el GET)
                        ViewBag.DireccionesCoordsJson = JsonSerializer.Serialize(
                            direcciones.Select(d => new
                            {
                                id = d.Id,
                                lat = d.Latitud,
                                lng = d.Longitud,
                                texto = $"{d.Barrio} - {d.Calle} {d.Numero}"
                            })
                        );
                    }
                }

                // Repartidores
                model.Repartidores = await _context.Repartidores
                    .Where(r => r.Activo)
                    .Select(r => new SelectListItem
                    {
                        Value = r.Id.ToString(),
                        Text = r.NombreCompleto
                    }).ToListAsync();

                // ViewBag de zonas para tiempo estimado
                ViewBag.ZonasDatosJson = JsonSerializer.Serialize(
                    zonas.Select(z => new
                    {
                        id = z.Id,
                        nombre = z.NombreZona,
                        minutos = z.TiempoEstimadoMinutos
                    })
                );

                return View(model);
            }

            // 🔹 Lógica extra: si no se escribió costo pero hay zona, usar costo base de la zona
            decimal costoDomicilio = model.CostoDomicilio;
            if (costoDomicilio <= 0 && model.ZonaEntregaId.HasValue)
            {
                var zona = await _context.ZonasEntrega
                    .FirstOrDefaultAsync(z => z.Id == model.ZonaEntregaId.Value);
                if (zona != null)
                {
                    costoDomicilio = zona.CostoDomicilioBase;
                }
            }

            var domicilio = new Domicilio
            {
                PedidoId = model.PedidoId,
                DireccionClienteId = model.DireccionClienteId,
                ZonaEntregaId = model.ZonaEntregaId,
                RepartidorId = model.RepartidorId,
                EstadoDomicilio = EstadoDomicilio.Pendiente,
                HoraSolicitud = DateTime.Now,
                CostoDomicilio = costoDomicilio,
                Propina = model.Propina,
                Notas = model.Notas
            };

            _context.Domicilios.Add(domicilio);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // -------------------------------------------------------
        // EDITAR
        // -------------------------------------------------------
        // GET: Domicilios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var domicilio = await _context.Domicilios
                .Include(d => d.Pedido)
                    .ThenInclude(p => p.Cliente)
                .Include(d => d.DireccionCliente)
                .Include(d => d.ZonaEntrega)
                .Include(d => d.Repartidor)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (domicilio == null)
                return NotFound();

            await RellenarCombosEditAsync(domicilio);
            return View(domicilio);
        }

        // POST: Domicilios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Domicilio domicilio)
        {
            if (id != domicilio.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await RellenarCombosEditAsync(domicilio);
                return View(domicilio);
            }

            // Cargar original para no perder campos como HoraSolicitud
            var domicilioDb = await _context.Domicilios.FindAsync(id);
            if (domicilioDb == null)
                return NotFound();

            domicilioDb.DireccionClienteId = domicilio.DireccionClienteId;
            domicilioDb.ZonaEntregaId = domicilio.ZonaEntregaId;
            domicilioDb.RepartidorId = domicilio.RepartidorId;
            domicilioDb.EstadoDomicilio = domicilio.EstadoDomicilio;
            domicilioDb.CostoDomicilio = domicilio.CostoDomicilio;
            domicilioDb.Propina = domicilio.Propina;
            domicilioDb.Notas = domicilio.Notas;
            domicilioDb.HoraAsignacion = domicilio.HoraAsignacion;
            domicilioDb.HoraSalida = domicilio.HoraSalida;
            domicilioDb.HoraEntrega = domicilio.HoraEntrega;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task RellenarCombosEditAsync(Domicilio domicilio)
        {
            // Direcciones según el cliente del pedido
            var direcciones = new List<DireccionCliente>();

            if (domicilio.PedidoId.HasValue)
            {
                var pedido = await _context.Pedidos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == domicilio.PedidoId.Value);

                if (pedido != null)
                {
                    direcciones = await _context.DireccionesCliente
                        .Where(d => d.ClienteId == pedido.ClienteId)
                        .ToListAsync();
                }
            }

            ViewBag.DireccionClienteId = new SelectList(
                direcciones,
                "Id",
                "Barrio",
                domicilio.DireccionClienteId
            );

            ViewBag.ZonaEntregaId = new SelectList(
                await _context.ZonasEntrega.ToListAsync(),
                "Id",
                "NombreZona",
                domicilio.ZonaEntregaId
            );

            ViewBag.RepartidorId = new SelectList(
                await _context.Repartidores.Where(r => r.Activo).ToListAsync(),
                "Id",
                "NombreCompleto",
                domicilio.RepartidorId
            );
        }

        // -------------------------------------------------------
        // ELIMINAR
        // -------------------------------------------------------
        // GET: Domicilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var domicilio = await _context.Domicilios
                .Include(d => d.Pedido)
                    .ThenInclude(p => p.Cliente)
                .Include(d => d.DireccionCliente)
                .Include(d => d.ZonaEntrega)
                .Include(d => d.Repartidor)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (domicilio == null)
                return NotFound();

            return View(domicilio);
        }

        // POST: Domicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domicilio = await _context.Domicilios.FindAsync(id);
            if (domicilio != null)
            {
                _context.Domicilios.Remove(domicilio);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
