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
    public class RolMap
    {
        RolPermisoMap rolPermisoMap;
        public RolMap()
        {
            rolPermisoMap = new RolPermisoMap();
        }

        public bool AltaRol(Rol rol)
        {
            // modificar y codificar codigo  para encontrar maximo indice
            rol.Id = SiguienteMayorId();

            //Agrego la estructura al XML
            AccesoADatos.Instance.data.Element("roles").Add(new XElement("rol",
                                        new XAttribute("id", rol.Id.ToString().Trim()),
                                        new XElement("nombre", rol.Nombre.ToString().Trim())));

            //Guardo lo ingresado a mi archivo
            AccesoADatos.Instance.GuardarXml();
            return true;
        }

        public void Borrar(string Id)
        {
            //consulto por algun campo en este caso por el atribnuto ID
            //puedo consultar por elemento también
            var consulta = from rol in AccesoADatos.Instance.data.Descendants("rol")
                           where rol.Attribute("id").Value == Id
                           select rol;
            //metodo remove borro todo el nodo
            consulta.Remove();

            var listaPermisos = rolPermisoMap.ListarRelacion(Convert.ToInt32(Id));

            foreach ( var item in listaPermisos)
            {
                rolPermisoMap.Borrar(Id, item.PermisoId.ToString());
            }

            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml(); ;
        }

        public static int SiguienteMayorId()
        {
            var maxId = AccesoADatos.Instance.data.Descendants("rol")
                .Select(element => (int?)element.Attribute("id"))
                .Where(id => id.HasValue)
                .Max() ?? 0;

            if (maxId == 0)
            {
                maxId = 1;
                return maxId;
            }
            else
            {
                maxId++;
                return maxId;
            }
        }

        public List<Rol> ListarRoles()
        {
            var leer =
                from rol in AccesoADatos.Instance.data.Elements("roles").Elements("rol")
                select new Rol
                {
                    Id = Convert.ToInt32(Convert.ToString(rol.Attribute("id").Value).Trim()),
                    Nombre = Convert.ToString(rol.Element("nombre").Value).Trim()
                };
            List<Rol> roles = leer.ToList();

            return roles;
        }
    }
}
