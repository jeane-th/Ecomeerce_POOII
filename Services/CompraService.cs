using Skart.Entities;
using Skart.DAL;
using System.Collections.Generic;

namespace Skart.Services
{
    public class CompraService
    {
        private readonly CompraDAL compraDAL = new CompraDAL();

        public int CrearCompra(int proveedorId, List<CompraDetalle> detalles)
            => compraDAL.InsertarCompra(proveedorId, detalles);

        public List<CompraProveedor> ListarCompras() => compraDAL.ListarCompras();
    }
}