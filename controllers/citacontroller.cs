using AgendamientosBarberia.Data;
using AgendamientosBarberia.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgendamientosBarberia.Controllers
{
    public class CitaController
    {
        private readonly ConexionBD _conexion;

        public CitaController()
        {
            _conexion = new ConexionBD();
        }

        public void AgregarCita(Cita cita)
        {
            using (SqlConnection conn = _conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "INSERT INTO Cita (Nombre, Telefono, Hora, Paquete, Fecha, Estado) " + "VALUES (@Nombre, @Telefono, @Hora, @Paquete, @Fecha, @Estado)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", cita.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", cita.Telefono);
                cmd.Parameters.AddWithValue("@Hora", cita.Hora);
                cmd.Parameters.AddWithValue("@Paquete", cita.Paquete);
                cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
                cmd.Parameters.AddWithValue("@Estado", cita.Estado);

                cmd.ExecuteNonQuery();
            }
        }

        public void CancelarCita(int idCita)
        {
            using (SqlConnection conn = _conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Cita WHERE IdCita = @IdCita";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCita", idCita);

                cmd.ExecuteNonQuery();
            }
        }

public List<Cita> ObtenerCitas()
{
    List<Cita> citas = new List<Cita>();
    using (SqlConnection conn = _conexion.ObtenerConexion())
    {
        conn.Open();
        string query = "SELECT IdCita AS Id, Nombre, Telefono, Hora, Paquete, Fecha, Estado FROM Cita";
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Cita cita = new Cita
            {
                IdCita = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Telefono = reader.GetString(2),
                Hora = reader.GetString(3),
                Paquete = reader.GetString(4),
                Fecha = reader.GetDateTime(5),
                Estado = reader.GetString(6)
            };
            citas.Add(cita);
        }
    }
    return citas;
}

public void ModificarCita(Cita cita)
{
    using (SqlConnection conn = _conexion.ObtenerConexion())
    {
        conn.Open();
        string query = "UPDATE Cita SET Nombre=@Nombre, Telefono=@Telefono, Hora=@Hora, Paquete=@Paquete, Fecha=@Fecha " +
                    "WHERE IdCita=@Id";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", cita.IdCita);
        cmd.Parameters.AddWithValue("@Nombre", cita.Nombre);
        cmd.Parameters.AddWithValue("@Telefono", cita.Telefono);
        cmd.Parameters.AddWithValue("@Hora", cita.Hora);
        cmd.Parameters.AddWithValue("@Paquete", cita.Paquete);
        cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
        cmd.ExecuteNonQuery();
    }
}

public void ConfirmarCita(int idCita)
{
    using (SqlConnection conn = _conexion.ObtenerConexion())
    {
        conn.Open();
        string query = "UPDATE Cita SET Estado='Confirmada' WHERE IdCita=@Id";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", idCita);
        cmd.ExecuteNonQuery();
    }
}

public List<string> HorasOcupadas(DateTime fecha)
{
    List<string> horas = new List<string>();
    using (SqlConnection conn = _conexion.ObtenerConexion())
    {
        conn.Open();
        string query = "SELECT Hora FROM Cita WHERE Fecha=@Fecha";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Fecha", fecha);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            horas.Add(reader.GetString(0));
        }
    }
    return horas;
}
    }

}
