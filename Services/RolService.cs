using Skart.Entities;
using Skart.DAL;
using System.Collections.Generic;

namespace Skart.Services
{
    public class RolService
    {
        private readonly RolDAL rolDAL = new RolDAL();

        public int CrearRol(Rol r) => rolDAL.Insertar(r);

        public List<Rol> ListarRoles() => rolDAL.Listar();

        public void EliminarRol(int id) => rolDAL.Eliminar(id);
    }
}