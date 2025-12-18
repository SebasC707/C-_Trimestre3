using Microsoft.AspNetCore.Mvc;
using Taller1.Data;
using Taller1.Models;

namespace Taller1.Controllers {
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            Console.WriteLine($"➡ POST recibido: Nombre={cliente.Nombre}, Documento={cliente.Documento}");

            if (ModelState.IsValid)
            {
                Console.WriteLine("✅ ModelState válido, guardando...");
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                Console.WriteLine("💾 Cliente guardado correctamente.");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("❌ ModelState inválido");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/{id}
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: Cliente/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/{id}
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: Cliente/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}