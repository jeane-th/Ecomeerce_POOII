using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required, StringLength(50)]
        public string NombreRol { get; set; }
    }
}