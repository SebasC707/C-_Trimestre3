using Microsoft.AspNetCore.Mvc;
using Taller1.Data;
using Taller1.Models;

namespace Taller1.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Producto
        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Producto/Edit/{id}
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();

            return View(producto);
        }

        // POST: Producto/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Producto/Delete/{id}
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();

            return View(producto);
        }

        // POST: Producto/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
