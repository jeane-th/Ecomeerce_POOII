using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class CompraDetalle
    {
        [Key]
        public int CompraDetalleId { get; set; }

        [Required]
        public int CompraId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required, Range(0.01, 999999)]
        public decimal PrecioUnitario { get; set; }

        [Range(0.01, 999999)]
        public decimal Subtotal { get; set; }
    }
}