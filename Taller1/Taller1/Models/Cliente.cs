using System.ComponentModel.DataAnnotations;

namespace Taller1.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }  // 👈 Debe ser público

        public string Nombre { get; set; }
        public string Documento {  get; set; }

        // Relación: un cliente tiene muchas ventas
        public ICollection<Venta >? Ventas { get; set; }
    }
}
