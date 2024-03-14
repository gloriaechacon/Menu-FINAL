using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public abstract class Componente
    {
        public abstract bool TienePermisos(string permiso);
    }
}
