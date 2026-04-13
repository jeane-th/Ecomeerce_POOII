using Skart.Entities;
using Skart.DAL;
using System.Collections.Generic;

namespace Skart.Services
{
    public class CategoriaService
    {
        private readonly CategoriaDAL categoriaDAL = new CategoriaDAL();

        public int CrearCategoria(Categoria c) => categoriaDAL.Insertar(c);

        public Categoria ObtenerCategoria(int id) => categoriaDAL.ObtenerPorId(id);

        public List<Categoria> ListarCategorias() => categoriaDAL.Listar();

        public void ActualizarCategoria(Categoria c) => categoriaDAL.Actualizar(c);

        public void EliminarCategoria(int id) => categoriaDAL.Eliminar(id);
    }
}