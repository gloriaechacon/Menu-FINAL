using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClienteManager
    {
        private readonly ClienteMap mapper;
        public ClienteManager()
        {
            mapper = new ClienteMap();
        }
        public List<Cliente> Listar()
        {
            return mapper.ListarClientes();
        }
        public bool AltaCliente(Cliente cliente)
        {
            return mapper.AltaCliente(cliente);
        }
        public bool Guardar(Cliente cliente)
        {
            return mapper.Guardar(cliente);
        }
        public void Borrar(string id)
        {
            mapper.Borrar(id);
        }
        public bool ExisteDni(string dni)
        {
            return mapper.ExisteDni(dni);
        }

        public int TotalClientes()
        {
            return mapper.TotalClientes();
        }

        public bool ExisteAlquilerSala(int clienteId)
        {
            return mapper.ExisteAlquilerSala(clienteId);
        }

        public bool ExisteAlquilerInstrumento(int clienteId)
        {
            return mapper.ExisteAlquilerInstrumento(clienteId);
        }
    }
}
