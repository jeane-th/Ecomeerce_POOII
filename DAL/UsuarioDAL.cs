using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Skart.Entities;

namespace Skart.DAL
{
    public class UsuarioDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SkartDB"].ConnectionString;

        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Usuario
                    {
                        UsuarioId = (int)reader["UsuarioId"],
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Email = reader["Email"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Salt = reader["Salt"].ToString(),
                        FechaRegistro = (DateTime)reader["FechaRegistro"],
                        Estado = (bool)reader["Estado"]
                    });
                }
            }
            return lista;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuarios WHERE UsuarioId=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        UsuarioId = (int)reader["UsuarioId"],
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Email = reader["Email"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Salt = reader["Salt"].ToString(),
                        FechaRegistro = (DateTime)reader["FechaRegistro"],
                        Estado = (bool)reader["Estado"]
                    };
                }
            }
            return usuario;
        }

        public int Insertar(Usuario u)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();
                try
                {
                    string query = @"INSERT INTO Usuarios (NombreUsuario,Email,PasswordHash,Salt,Estado)
                             VALUES (@Nombre,@Email,@Pass,@Salt,@Estado);
                             SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conn, tx);
                    cmd.Parameters.AddWithValue("@Nombre", u.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Email", u.Email);
                    cmd.Parameters.AddWithValue("@Pass", u.PasswordHash);
                    cmd.Parameters.AddWithValue("@Salt", u.Salt);
                    cmd.Parameters.AddWithValue("@Estado", u.Estado);
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

        public void Actualizar(Usuario u)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Usuarios SET NombreUsuario=@Nombre,Email=@Email,
                                 PasswordHash=@Hash,Salt=@Salt,Estado=@Estado WHERE UsuarioId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Hash", u.PasswordHash);
                cmd.Parameters.AddWithValue("@Salt", u.Salt);
                cmd.Parameters.AddWithValue("@Estado", u.Estado);
                cmd.Parameters.AddWithValue("@Id", u.UsuarioId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuarios WHERE UsuarioId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}