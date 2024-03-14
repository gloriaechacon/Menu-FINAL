using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario : Persona
    {
        public string Username { get; set; }
        public string Clave { get; set; }
        public Rol Rol { get; set; }
        public int RolId { get; set; }
    }
}
