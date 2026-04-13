using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Skart.Entities;

namespace Skart.DAL
{
    public class CategoriaDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SkartDB"].ConnectionString;

        public List<Categoria> Listar()
        {
            var lista = new List<Categoria>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categorias";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Categoria
                    {
                        CategoriaId = (int)reader["CategoriaId"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Activo = (bool)reader["Activo"]
                    });
                }
            }
            return lista;
        }

        public Categoria ObtenerPorId(int id)
        {
            Categoria categoria = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categorias WHERE CategoriaId=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    categoria = new Categoria
                    {
                        CategoriaId = (int)reader["CategoriaId"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Activo = (bool)reader["Activo"]
                    };
                }
            }
            return categoria;
        }

        public int Insertar(Categoria c)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();
                try
                {
                    string query = @"INSERT INTO Categorias (Nombre,Descripcion,Activo)
                             VALUES (@Nombre,@Desc,@Activo); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conn, tx);
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Desc", c.Descripcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Activo", c.Activo);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    tx.Commit();
                    return id;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void Actualizar(Categoria c)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Categorias SET Nombre=@Nombre,Descripcion=@Desc,Activo=@Activo
                                 WHERE CategoriaId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Desc", c.Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", c.Activo);
                cmd.Parameters.AddWithValue("@Id", c.CategoriaId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Categorias WHERE CategoriaId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}