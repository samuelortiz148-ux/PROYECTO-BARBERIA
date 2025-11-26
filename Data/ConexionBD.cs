using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AgendamientosBarberia.Data
{
    public class ConexionBD
    {
        private string CadenaConexion = "Server=VIVOBOOKDANIEL\\SQLEXPRESS;Database=BarberiaDB;Trusted_Connection=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}
