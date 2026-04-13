using System;
using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required, StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string PasswordHash { get; set; }

        [Required, StringLength(50)]
        public string Salt { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        public bool Estado { get; set; }
    }
}