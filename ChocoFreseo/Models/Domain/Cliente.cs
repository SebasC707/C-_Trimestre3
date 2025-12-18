using System.ComponentModel.DataAnnotations;

namespace ChocoFreseo.Models.Domain
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string NombreCompleto { get; set; } = null!;

        [StringLength(20)]
        public string? Telefono { get; set; }

        [EmailAddress, StringLength(150)]
        public string? Email { get; set; }

        [StringLength(250)]
        public string? Observaciones { get; set; }

        public ICollection<DireccionCliente> Direcciones { get; set; } = new List<DireccionCliente>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
