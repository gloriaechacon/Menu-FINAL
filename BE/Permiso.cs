using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Permiso : Entity
    {
        public string Nombre { get; set; }
        public List<Rol> Roles { get; set; }
    }
}
