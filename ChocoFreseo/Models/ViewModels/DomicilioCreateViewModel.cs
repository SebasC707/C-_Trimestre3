using ChocoFreseo.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChocoFreseo.Models.ViewModels
{
    public class DomicilioCreateViewModel
    {
        // Datos base
        public int? PedidoId { get; set; }
        public int? DireccionClienteId { get; set; }
        public int? ZonaEntregaId { get; set; }
        public int? RepartidorId { get; set; }

        public decimal CostoDomicilio { get; set; }
        public decimal? Propina { get; set; }
        public string? Notas { get; set; }

        // Para mostrar info en la vista
        public Pedido? Pedido { get; set; }
        public Cliente? Cliente { get; set; }

        // Combos
        public List<SelectListItem> DireccionesCliente { get; set; } = new();
        public List<SelectListItem> ZonasEntrega { get; set; } = new();
        public List<SelectListItem> Repartidores { get; set; } = new();
    }
}
