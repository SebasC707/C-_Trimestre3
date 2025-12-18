using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChocoFreseo.Models.Domain
{
    public class Domicilio
    {
        public int Id { get; set; }

        // RELACIONES OPCIONALES → NO HAY CASCADE
        public int? PedidoId { get; set; }
        public int? DireccionClienteId { get; set; }
        public int? ZonaEntregaId { get; set; }
        public int? RepartidorId { get; set; }

        public EstadoDomicilio EstadoDomicilio { get; set; } = EstadoDomicilio.Pendiente;

        public DateTime HoraSolicitud { get; set; } = DateTime.Now;
        public DateTime? HoraAsignacion { get; set; }
        public DateTime? HoraSalida { get; set; }
        public DateTime? HoraEntrega { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CostoDomicilio { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Propina { get; set; }

        [StringLength(250)]
        public string? Notas { get; set; }

        // Navegación
        public Pedido? Pedido { get; set; }
        public DireccionCliente? DireccionCliente { get; set; }
        public ZonaEntrega? ZonaEntrega { get; set; }
        public Repartidor? Repartidor { get; set; }
    }
}
