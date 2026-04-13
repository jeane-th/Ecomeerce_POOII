using System;
using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class Carrito
    {
        [Key]
        public int CarritoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Required, StringLength(20)]
        public string Estado { get; set; }
    }
}