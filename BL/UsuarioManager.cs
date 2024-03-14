using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioManager
    {
        private readonly UsuarioMap mapper;
        public UsuarioManager()
        {
            mapper = new UsuarioMap();
        }
        public List<Usuario> Listar()
        {
            return mapper.ListarUsuarios();
        }
        public bool Guardar(Usuario usuario)
        {
            return mapper.Guardar(usuario);
        }
        public void Borrar(string id)
        {
            mapper.Borrar(id);
        }
        public bool ExisteDni(string dni)
        {
            return mapper.ExisteDni(dni);
        }
        public bool ExisteUsuario(string username)
        {
            return mapper.ExisteUsuario(username);
        }

        public bool Loguear(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }
            else
            {
                return mapper.Loguear(usuario);
            }
        }

        public string ObtenerClave(int id)
        {
            return mapper.ObtenerClave(id);
        }

        public int TotalEmpleados()
        {
            return mapper.TotalEmpleados();
        }

        public bool ExisteRolUsuario(int rolId)
        {
            return mapper.ExisteRolUsuario(rolId);
        }
    }
}
