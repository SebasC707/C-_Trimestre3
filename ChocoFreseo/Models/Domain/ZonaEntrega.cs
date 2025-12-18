using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChocoFreseo.Models.Domain
{
    public class ZonaEntrega
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NombreZona { get; set; } = null!;

        [Column(TypeName = "decimal(10,2)")]
        public decimal CostoDomicilioBase { get; set; }

        public int TiempoEstimadoMinutos { get; set; }
    }
}
