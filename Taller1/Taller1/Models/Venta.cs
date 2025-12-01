using System.ComponentModel.DataAnnotations;

namespace Taller1.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Total { get; set; }

        // Relación con Cliente
        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Relación con Productos (muchos a muchos)
        public ICollection<VentaProducto>? VentaProductos { get; set; }
    }
}
