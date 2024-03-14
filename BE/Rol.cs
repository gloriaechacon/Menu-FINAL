using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Rol : Entity
    {
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
        public List<Permiso> Permisos { get; set; }
    }
}
