using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Persona : Entity
    {
        //Defino propiedades de la clase
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Datos => $"{Nombre} {Apellido}";
        public string DatosCompletos => $"{Nombre} {Apellido}  DNI: {DNI}";
    }
}
