using System;
using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class InventarioMovimiento
    {
        [Key]
        public int MovimientoId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required, StringLength(20)]
        public string TipoMovimiento { get; set; } // Entrada / Salida

        [Required, Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaMovimiento { get; set; }

        [StringLength(100)]
        public string Referencia { get; set; }
    }
}