using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChocoFreseo.Models.Domain
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }

        public EstadoPedido EstadoPedido { get; set; } = EstadoPedido.Pendiente;

        [StringLength(50)]
        public string? MetodoPago { get; set; }

        [StringLength(250)]
        public string? Observaciones { get; set; }

        [ValidateNever]
        public Cliente Cliente { get; set; } = null!;
        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
        public Domicilio? Domicilio { get; set; }
    }
}
