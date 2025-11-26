using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosBarberia.Models
{
    public class Cliente
    {
        public string NombreUsu { get; set; }
        public string Telelfono { get; set; }
        public int Edad { get; set; }

        public string Clave { get; set; }

        public Cliente(string nombreusu, string telelfono, int edad, string clave)
        {
            NombreUsu = nombreusu;
            Telelfono = telelfono;
            Edad = edad;
            Clave = clave;
        }
    }
}
