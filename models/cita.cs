using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosBarberia.Models
{
    public class Cita
    {
        public int IdCita { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Hora { get; set; }
        public string Paquete { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public Cita()
        {
            
        }

        public Cita(string nombre, string telefono, string hora, string paquete ) 
        {
            Nombre = nombre;
            Telefono = telefono;
            Hora = hora;
            Paquete = paquete;
        }
    }
}
