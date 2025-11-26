using AgendamientosBarberia.Models;
using AgendamientosBarberia.Data;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AgendamientosBarberia.Controllers
{
    public class ClienteControllers
    {
        private ConexionBD conexion = new ConexionBD();

        public void AgregarCliente(Cliente cliente)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "INSERT INTO Clientes (Nombre, Telefono, Edad, Clave) " +
                    "VALUES (@nombre, @telefono, @edad, @clave)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", cliente.NombreUsu);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telelfono);
                cmd.Parameters.AddWithValue("@edad", cliente.Edad);
                cmd.Parameters.AddWithValue("@clave", cliente.Clave);
                 cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerClientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT IdCliente, Nombre, Telefono, Edad, Clave FROM Clientes";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        
        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Clientes WHERE IdCliente = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idCliente);
                cmd.ExecuteNonQuery();
            }
        } 
    }
}

