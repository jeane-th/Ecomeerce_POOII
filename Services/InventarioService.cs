//InventarioService / KardexServic
using Skart.Entities;
using Skart.DAL;
using System.Collections.Generic;

namespace Skart.Services
{
    public class InventarioService
    {
        private readonly InventarioDAL inventarioDAL = new InventarioDAL();

        public int RegistrarMovimiento(InventarioMovimiento mov) => inventarioDAL.InsertarMovimiento(mov);

        public List<InventarioMovimiento> ListarMovimientos(int productoId) => inventarioDAL.ListarMovimientos(productoId);
    }

    
}