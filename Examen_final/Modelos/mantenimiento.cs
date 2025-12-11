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
    internal class mantenimiento
    {
        public static DataTable obtener()
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "SELECT m.*,e.nombre FROM mantenimientos m left join equipos e on m.id_equipo=e.id left join  empleados em  on m.id_empleado=em.id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los mantenimientos: " + ex.Message);
                return null;
            }
            finally
            {
                cnn.desconectar();
            }

        }
        public static bool Crear(string tipo, string detalles,string costo, string fechayhora_recepcion, string fechayhora_devolucion,int id_equipo,int id_empleado)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "INSERT INTO mantenimientos (tipo, detalles, costo, fechayhora_recepcion,fechayhora_devolucion,id_equipo,id_empleado) VALUES (@tipo, @detalles, @costo, @fechayhora_recepcion, @fechayhora_devolucion,@id_equipo,@id_empleado)";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@detalles", detalles);
                cmd.Parameters.AddWithValue("@costo", costo);
                cmd.Parameters.AddWithValue("@fechayhora_devolucion", fechayhora_devolucion);
                cmd.Parameters.AddWithValue("@fechayhora_recepcion", fechayhora_recepcion);
                cmd.Parameters.AddWithValue("@id_equipo", id_equipo);
                cmd.Parameters.AddWithValue("@id_empleado", id_empleado);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el mantenimiento: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Editar(int mantenimientos_id, string tipo, string detalles, string costo, string fechayhora_recepcion, string fechayhora_devolucion,int id_equipo,int id_empleado)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "UPDATE mantenimientos SET tipo=@tipo, detalles=@detalles, costo=@costo, fechayhora_recepcion=@fechayhora_recepcion, fechayhora_devolucion=@fechayhora_devolucion, id_equipo=@id_equipo, id_empleado=@id_empleado WHERE id=@id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@detalles", detalles);
                cmd.Parameters.AddWithValue("@costo", costo);
                cmd.Parameters.AddWithValue("@fechayhora_recepcion", fechayhora_recepcion);
                cmd.Parameters.AddWithValue("@fechayhora_devolucion", fechayhora_devolucion);
                cmd.Parameters.AddWithValue("@id_equipo", id_equipo);
                cmd.Parameters.AddWithValue("@id_empleado", id_empleado);
                cmd.Parameters.AddWithValue("@id", mantenimientos_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el Mantenimiento: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
        public static bool Eliminar(int mantenimientos_id)
        {
            conexion cnn = new conexion();
            try
            {
                cnn.conectar();
                string consulta = "DELETE FROM mantenimientos WHERE id=@id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.conectar());
                cmd.Parameters.AddWithValue("@id", mantenimientos_id);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar mantenimiento: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.desconectar();
            }
        }
    }
}
