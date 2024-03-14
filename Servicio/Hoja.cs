using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Hoja : Componente
    {
        public string Nombre { get; set; }
        public bool TieneAcceso { get; set; }
        public override bool TienePermisos(string permiso)
        {
            return TieneAcceso && Nombre == permiso;
        }
    }
}
