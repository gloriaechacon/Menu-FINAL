using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RolPermisoManager
    {
        private readonly RolPermisoMap mapper;
        public RolPermisoManager()
        {
            mapper = new RolPermisoMap();
        }
        public bool ActualizarPermisos(int rolId, List<int> permisos)
        {
            return mapper.ActualizarPermisos(rolId, permisos);
        }
        public void Borrar(string rolId, string permisoId)
        {
            mapper.Borrar(rolId, permisoId);
        }
        public List<RolPermiso> ListarRelacion(int rolid)
        {
            return mapper.ListarRelacion(rolid);
        }
    }
}
