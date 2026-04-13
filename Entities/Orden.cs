using System;
using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class Orden
    {
        [Key]
        public int OrdenId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaOrden { get; set; }

        [Required, Range(0.01, 999999)]
        public decimal Total { get; set; }

        [Required, StringLength(20)]
        public string Estado { get; set; }
    }
}