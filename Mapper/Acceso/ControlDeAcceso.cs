using BE;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Acceso
{
    public class ControlDeAcceso
    {
        RolMap rolMap;
        PermisoMap permisoMap;
        RolPermisoMap rolPermisoMap;
        public ControlDeAcceso()
        {
            rolMap = new RolMap();
            permisoMap = new PermisoMap();
            rolPermisoMap = new RolPermisoMap();
        }
        public void VerificarAcceso(Usuario usuario)
        {
            ApplicationGlobalContext.Instance.Usuario = usuario;
            var roles = rolMap.ListarRoles();
            var permisos = permisoMap.ListarPermisos();
            var rolPermisos = rolPermisoMap.ListarRelacion(usuario.RolId);
            var acceso = ApplicationGlobalContext.Instance.AccessControl;
            foreach (var rol in roles)
            {
                var nodo = new Composite();
                acceso.AgregarHijo(nodo);
                foreach (var permiso in permisos)
                {
                    var hoja = new Hoja();
                    hoja.Nombre = permiso.Nombre;
                    hoja.TieneAcceso = usuario.RolId == rol.Id && rolPermisos.Exists(x => x.PermisoId == permiso.Id);
                    nodo.AgregarHijo(hoja);
                }
            }
        }
    }
}
