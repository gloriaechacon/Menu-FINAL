using BE;
using DAL;
using Mapper.Acceso;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mapper
{
    public class UsuarioMap
    {
        private readonly RolMap rolMap;
        private readonly PermisoMap permisoMap;
        private readonly ControlDeAcceso acceso;
        public UsuarioMap()
        {
            rolMap = new RolMap();
            permisoMap = new PermisoMap();
            acceso = new ControlDeAcceso();
        }
        public List<Usuario> ListarUsuarios()
        {
            var leer =
                from usuario in AccesoADatos.Instance.data.Elements("usuarios").Elements("usuario")
                select new Usuario
                {
                    Id = Convert.ToInt32(Convert.ToString(usuario.Attribute("id").Value).Trim()),
                    Nombre = Convert.ToString(usuario.Element("nombre").Value).Trim(),
                    Apellido = Convert.ToString(usuario.Element("apellido").Value).Trim(),
                    DNI = Convert.ToInt32(Convert.ToString(usuario.Element("dni").Value).Trim()),
                    Username = Convert.ToString(usuario.Element("username").Value).Trim(),
                    Clave = "******",
                    Rol = ObtenerRol(Convert.ToInt32(Convert.ToString(usuario.Element("rolid").Value).Trim()))
                };
            List<Usuario> usuarios = leer.ToList();

            return usuarios;
        }

        public bool Guardar(Usuario usuario)
        {
            if (usuario.Id == 0) //Crear
            {
                // modificar y codificar codigo  para encontrar maximo indice
                usuario.Id = SiguienteMayorId();

                //Agrego la estructura al XML
                AccesoADatos.Instance.data.Element("usuarios").Add(new XElement("usuario",
                                            new XAttribute("id", usuario.Id.ToString().Trim()),
                                            new XElement("nombre", usuario.Nombre.ToString().Trim()),
                                            new XElement("apellido", usuario.Apellido.ToString().Trim()),
                                            new XElement("dni", usuario.DNI.ToString().Trim()),
                                            new XElement("username", usuario.Username.ToString().Trim()),
                                            new XElement("clave", usuario.Clave.ToString().Trim()),
                                            new XElement("rolid", usuario.Rol.Id.ToString().Trim())));

                //Guardo lo ingresado a mi archivo
                AccesoADatos.Instance.GuardarXml();
            }
            else //Modificar
            {
                //consulto por algun campo en este caso por el atribnuto ID
                //puedo consultar por elemento también
                var consulta = from user in AccesoADatos.Instance.data.Descendants("usuario")
                               where user.Attribute("id").Value == usuario.Id.ToString()
                               select user;

                //recorro la consulta y modifico el elemento de la consulta
                foreach (XElement EModifcar in consulta)
                {
                    //recorro y le paso los nuevos valores 
                    EModifcar.Element("nombre").Value = usuario.Nombre.Trim();
                    EModifcar.Element("apellido").Value = usuario.Apellido.Trim();
                    EModifcar.Element("dni").Value = usuario.DNI.ToString().Trim();
                    EModifcar.Element("username").Value = usuario.Username.ToString().Trim();
                    EModifcar.Element("clave").Value = usuario.Clave.ToString().Trim();
                    EModifcar.Element("rolid").Value = usuario.Rol.Id.ToString().Trim();
                }

                //despues de modificar , guardo el archivo XML para que impacte el cambio
                AccesoADatos.Instance.GuardarXml();
            }
            return true;

        }
        public void Borrar(string Id)
        {
            //consulto por algun campo en este caso por el atribnuto ID
            //puedo consultar por elemento también
            var consulta = from user in AccesoADatos.Instance.data.Descendants("usuario")
                           where user.Attribute("id").Value == Id
                           select user;
            //metodo remove borro todo el nodo
            consulta.Remove();

            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml();
        }

        public bool ExisteUsuario(string user)
        {
            var consulta =
                from usuario in AccesoADatos.Instance.data.Elements("usuarios").Elements("usuario")
                where (string)usuario.Element("username") == user.ToString()
                select new Usuario
                {
                    Username = Convert.ToString(usuario.Element("username").Value).Trim(),

                };

            List<Usuario> numero = consulta.ToList();
            if (numero.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool ExisteDni(string dni)
        {
            var consulta =
                from usuario in AccesoADatos.Instance.data.Elements("usuarios").Elements("usuario")
                where (string)usuario.Element("dni") == dni.ToString()
                select new Usuario
                {
                    DNI = Convert.ToInt32(Convert.ToString(usuario.Element("dni").Value).Trim())
                };

            List<Usuario> numero = consulta.ToList();
            if (numero.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public static int SiguienteMayorId()
        {
            var maxId = AccesoADatos.Instance.data.Descendants("usuario")
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

        public bool Loguear(Usuario user)
        {
            var consulta =
                from usuario in AccesoADatos.Instance.data.Elements("usuarios").Elements("usuario")
                where (string)usuario.Element("username") == user.Username.ToString()
                where (string)usuario.Element("clave") == user.Clave.ToString()
                select new Usuario
                {
                    Username = Convert.ToString(usuario.Element("username").Value).Trim(),
                    RolId = Convert.ToInt32(usuario.Element("rolid").Value)
                };

            Usuario usuarioEncontrado = consulta.FirstOrDefault();
            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Rol = ObtenerRol(usuarioEncontrado.RolId);
                acceso.VerificarAcceso(usuarioEncontrado);
                return true;
            }
            return false;
        }  

        public string ObtenerClave(int id)
        {
            var consulta =
                from usuario in AccesoADatos.Instance.data.Elements("usuarios").Elements("usuario")
                where (string)usuario.Attribute("id") == id.ToString()
                select new Usuario
                {
                    Clave = Convert.ToString(usuario.Element("clave").Value).Trim()
                };


            List<Usuario> lista = consulta.ToList();
            foreach (var clave in lista)
            {
                return clave.Clave.ToString();
            }
            return null;
        }

        public Rol ObtenerRol(int id)
        {
            var consulta =
                from rol in AccesoADatos.Instance.data.Elements("roles").Elements("rol")
                where (string)rol.Attribute("id") == id.ToString()
                select new Rol
                {
                    Nombre = Convert.ToString(rol.Element("nombre").Value).Trim(),
                };


            List<Rol> lista = consulta.ToList();
            foreach (var resultado in lista)
            {
                return resultado;
            }
            return null;
        }

        public int TotalEmpleados()
        {
            var usuarios = ListarUsuarios();

            if (usuarios != null)
            {
                return usuarios.Count;
            }
            else
            {
                return 0;
            }
        }

        public bool ExisteRolUsuario(int rolId)
        {
            var consulta =
                from user in AccesoADatos.Instance.data.Elements("usuarios").Elements("usuario")
                where (string)user.Element("rolid") == rolId.ToString()
                select new Usuario
                {
                    Id = Convert.ToInt32(Convert.ToString(user.Attribute("id").Value).Trim())
                };

            List<Usuario> numero = consulta.ToList();
            if (numero.Count() > 0)
            {
                return true;
            }
            return false;
        }

    }
}
