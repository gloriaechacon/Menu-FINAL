using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mapper
{
    public class RolPermisoMap
    {
        public bool ActualizarPermisos(int rolId, List<int> permisos)
        {
            var tabla = AccesoADatos.Instance.data.Descendants("rolpermiso").Where(x => Convert.ToInt32(x.Element("rolid").Value) == rolId);
            var toRemove = tabla.Where(x => !permisos.Contains(Convert.ToInt32(x.Element("permisoid").Value))).ToList();
            var toAdd = permisos.Where(x => !tabla.Elements("permisoid").Select(y => Convert.ToInt32(y.Value)).Contains(x)).ToList();
            foreach (var item in toRemove)
            {
                item.Remove();
            }
            foreach(var item in toAdd)
            {
                AccesoADatos.Instance.data.Element("rolpermisos").Add(new XElement("rolpermiso",
                                        new XElement("rolid", rolId.ToString().Trim()),
                                        new XElement("permisoid", item.ToString().Trim())));
            }

            //Guardo lo ingresado a mi archivo
            AccesoADatos.Instance.GuardarXml();
            return true;
        }

        public void Borrar(string rolId, string permisoId)
        {
            //consulto por algun campo en este caso por el atribnuto ID
            //puedo consultar por elemento también
            var consulta = from rolPermiso in AccesoADatos.Instance.data.Descendants("rolpermiso")
                           where rolPermiso.Element("rolid").Value == rolId && rolPermiso.Element("permisoid").Value == permisoId
                           select rolPermiso;
            //metodo remove borro todo el nodo
            consulta.Remove();

            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml(); ;
        }

        public List<RolPermiso> ListarRelacion(int rolid)
        {
            var leer =
                from rolPermiso in AccesoADatos.Instance.data.Elements("rolpermisos").Elements("rolpermiso")
                where rolPermiso.Element("rolid").Value == rolid.ToString()
                select new RolPermiso
                {
                    RolId = Convert.ToInt32(Convert.ToString(rolPermiso.Element("rolid").Value).Trim()),
                    PermisoId = Convert.ToInt32(Convert.ToString(rolPermiso.Element("permisoid").Value).Trim())
                };
            List<RolPermiso> rolPermisos = leer.ToList();

            return rolPermisos;
        }
    }
}
