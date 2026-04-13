using System;
using System.ComponentModel.DataAnnotations;

namespace Skart.Entities
{
    public class CompraProveedor
    {
        [Key]
        public int CompraId { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }

        [Required, Range(0.01, 999999)]
        public decimal Total { get; set; }

        [Required, StringLength(20)]
        public string Estado { get; set; }
    }
}