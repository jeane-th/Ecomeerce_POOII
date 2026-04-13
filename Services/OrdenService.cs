using Skart.Entities;
using Skart.DAL;
using System.Collections.Generic;

namespace Skart.Services
{
    public class OrdenService
    {
        private readonly OrdenDAL ordenDAL = new OrdenDAL();

        public int CrearOrden(int usuarioId, List<OrdenDetalle> detalles)
            => ordenDAL.InsertarOrden(usuarioId, detalles);

        public List<Orden> ListarOrdenes() => ordenDAL.ListarOrdenes();
    }
}