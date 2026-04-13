using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Skart.Entities;

namespace Skart.DAL
{
    public class RolDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SkartDB"].ConnectionString;

        public List<Rol> Listar()
        {
            var lista = new List<Rol>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Roles";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Rol
                    {
                        RolId = (int)reader["RolId"],
                        NombreRol = reader["NombreRol"].ToString()
                    });
                }
            }
            return lista;
        }

        public Rol ObtenerPorId(int id)
        {
            Rol rol = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Roles WHERE RolId=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rol = new Rol
                    {
                        RolId = (int)reader["RolId"],
                        NombreRol = reader["NombreRol"].ToString()
                    };
                }
            }
            return rol;
        }

        public int Insertar(Rol r)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();
                try
                {
                    string query = @"INSERT INTO Roles (NombreRol) VALUES (@Nombre); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conn, tx);
                    cmd.Parameters.AddWithValue("@Nombre", r.NombreRol);
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

        public void Actualizar(Rol r)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Roles SET NombreRol=@Nombre WHERE RolId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", r.NombreRol);
                cmd.Parameters.AddWithValue("@Id", r.RolId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Roles WHERE RolId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}