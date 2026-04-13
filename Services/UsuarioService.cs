using Skart.Entities;
using Skart.DAL;
using System.Collections.Generic;

namespace Skart.Services
{
    public class UsuarioService
    {
        private readonly UsuarioDAL usuarioDAL = new UsuarioDAL();

        public int CrearUsuario(Usuario u) => usuarioDAL.Insertar(u);

        public Usuario ObtenerUsuario(int id) => usuarioDAL.ObtenerPorId(id);

        public List<Usuario> ListarUsuarios() => usuarioDAL.Listar();

        public void ActualizarUsuario(Usuario u) => usuarioDAL.Actualizar(u);

        public void EliminarUsuario(int id) => usuarioDAL.Eliminar(id);
    }
}