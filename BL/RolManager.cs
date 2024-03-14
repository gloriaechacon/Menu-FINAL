using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RolManager
    {
        private readonly RolMap mapper;
        public RolManager()
        {
            mapper = new RolMap();
        }
        public bool AltaRol(Rol rol)
        {
            return mapper.AltaRol(rol);
        }
        public void Borrar(string Id)
        {
            mapper.Borrar(Id);
        }
        public List<Rol> Listar()
        {
            return mapper.ListarRoles();
        }
    }
}
