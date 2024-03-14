using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente : Persona
    {
        public Cliente()
        {
        }
        public Cliente(string nombre, string apellido, int dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.DNI = dni;
        }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        //Relacion 1 a muchos 
        //public List<Alquiler> Alquileres { get; set; }

    }
}
