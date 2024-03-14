using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PermisoManager
    {
        private readonly PermisoMap mapper;
        public PermisoManager()
        {
            mapper = new PermisoMap();
        }
        
        public List<Permiso> Listar()
        {
            return mapper.ListarPermisos();
        }
    }
}
