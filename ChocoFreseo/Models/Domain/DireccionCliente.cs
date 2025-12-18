using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ChocoFreseo.Models.Domain
{
    public class DireccionCliente
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required, StringLength(80)]
        public string Barrio { get; set; } = null!;

        [Required, StringLength(80)]
        public string Calle { get; set; } = null!;

        [StringLength(20)]
        public string? Numero { get; set; }

        [StringLength(200)]
        public string? Referencia { get; set; }

        public bool EsPrincipal { get; set; }

        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        [ValidateNever]
        public Cliente Cliente { get; set; } = null!;
    }
}
