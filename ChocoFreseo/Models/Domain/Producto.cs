using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChocoFreseo.Models.Domain
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Nombre { get; set; } = null!;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [StringLength(80)]
        public string? Categoria { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<DetallePedido> DetallesPedido { get; set; } = new List<DetallePedido>();
    }
}
