using System.Collections.Generic;
using Skart.Entities;
using Skart.DAL;

namespace Skart.Services
{
    public class KardexService
    {
        private readonly InventarioDAL inventarioDAL = new InventarioDAL();

        public List<KardexItem> ObtenerKardex(int productoId)
        {
            return inventarioDAL.ObtenerKardexPorProducto(productoId);
        }
               

        public void InsertarKardex(KardexItem item) => inventarioDAL.InsertarKardex(item);

        public List<KardexItem> ObtenerKardexPorProducto(int productoId) => inventarioDAL.ObtenerKardexPorProducto(productoId);
    }
}