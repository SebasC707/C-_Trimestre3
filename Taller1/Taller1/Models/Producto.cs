using System.ComponentModel.DataAnnotations;

namespace Taller1.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }  // 👈 Público

        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }  // 👈 Nombres de propiedades en mayúscula por convención
        public DateTime FechaCreacion { get; set; }  // 👈 Corregido

        // Relación: un producto puede estar en muchas ventas
        public ICollection<VentaProducto>? VentaProductos { get; set; }
    }
}
