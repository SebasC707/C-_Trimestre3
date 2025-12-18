using System.ComponentModel.DataAnnotations;

namespace ChocoFreseo.Models.Domain
{
    public class Repartidor
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string NombreCompleto { get; set; } = null!;

        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(50)]
        public string? Documento { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Domicilio> Domicilios { get; set; } = new List<Domicilio>();
    }
}
