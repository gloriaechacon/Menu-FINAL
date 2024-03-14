using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mapper
{
    public class PermisoMap
    {
        public List<Permiso> ListarPermisos()
        {
            var leer =
                from permiso in AccesoADatos.Instance.data.Elements("permisos").Elements("permiso")
                select new Permiso
                {
                    Id = Convert.ToInt32(Convert.ToString(permiso.Attribute("id").Value).Trim()),
                    Nombre = Convert.ToString(permiso.Element("nombre").Value).Trim()
                };
            List<Permiso> permisos = leer.ToList();

            return permisos;
        }

    }
}
