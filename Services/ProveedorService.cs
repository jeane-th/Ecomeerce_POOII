using Skart.Entities;
using Skart.DAL;
using System.Collections.Generic;

namespace Skart.Services
{
    public class ProveedorService
    {
        private readonly ProveedorDAL proveedorDAL = new ProveedorDAL();

        public int CrearProveedor(Proveedor p) => proveedorDAL.Insertar(p);

        public List<Proveedor> ListarProveedores() => proveedorDAL.Listar();

        public Proveedor ObtenerProveedor(int id) => proveedorDAL.ObtenerProveedor((int)id);

        public void ActualizarProveedor(Proveedor p) => proveedorDAL.Actualizar(p);

        public void EliminarProveedor(int id) => proveedorDAL.Eliminar(id);
    }
}