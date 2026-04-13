using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}