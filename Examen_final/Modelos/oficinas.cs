using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_final.Modelos
{
    internal class oficinas
    {
        public static DataTable obtener()
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "SELECT * FROM oficinas";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los oficina: " + ex.Message);
                return null;
            }
            finally
            {
                cnn.desconectar();
            }

        }
        public static bool Crear(string tipo)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "INSERT INTO oficinas (tipo) " +
                                  "VALUES (@tipo  )";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@tipo", tipo);
                
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el autor: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Editar(int oficinas_id, string tipo)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "UPDATE oficinas SET tipo=@tipo " +
                                  "WHERE oficinas_id=@oficinas_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@oficinas_id", oficinas_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la oficinas: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Eliminar(int oficinas_id)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "DELETE FROM oficinas WHERE oficina_id=@oficinas_id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@oficinas_id", oficinas_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar oficinas: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
    }
}
