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
    public class ClienteMap
    {
        public List<Cliente> ListarClientes()
        {
            var leer =
                from cliente in AccesoADatos.Instance.data.Elements("clientes").Elements("cliente")
                select new Cliente
                {
                    Id = Convert.ToInt32(Convert.ToString(cliente.Attribute("id").Value).Trim()),
                    Nombre = Convert.ToString(cliente.Element("nombre").Value).Trim(),
                    Apellido = Convert.ToString(cliente.Element("apellido").Value).Trim(),
                    DNI = Convert.ToInt32(Convert.ToString(cliente.Element("dni").Value).Trim()),
                    Direccion = Convert.ToString(cliente.Element("direccion").Value).Trim(),
                    Telefono = Convert.ToString(cliente.Element("telefono").Value).Trim()
                };
            List<Cliente> clientes = leer.ToList();

            return clientes;
        }

        public bool Guardar(Cliente cliente)
        {
            if (cliente.Id == 0) //Crear
            {
                return AltaCliente(cliente);
            }
            else //Modificar
            {
                //consulto por algun campo en este caso por el atribnuto ID
                //puedo consultar por elemento también
                var consulta = from client in AccesoADatos.Instance.data.Descendants("cliente")
                               where client.Attribute("id").Value == cliente.Id.ToString()
                               select client;

                //recorro la consulta y modifico el elemento de la consulta
                foreach (XElement EModifcar in consulta)
                {
                    //recorro y le paso los nuevos valores 
                    EModifcar.Element("nombre").Value = cliente.Nombre.Trim();
                    EModifcar.Element("apellido").Value = cliente.Apellido.Trim();
                    EModifcar.Element("dni").Value = cliente.DNI.ToString().Trim();
                    EModifcar.Element("direccion").Value = cliente.Direccion.ToString().Trim();
                    EModifcar.Element("telefono").Value = cliente.Telefono.ToString().Trim();
                }

                //despues de modificar , guardo el archivo XML para que impacte el cambio
                AccesoADatos.Instance.GuardarXml();
                return true;
            }
        }

        public bool AltaCliente(Cliente cliente)
        {
            // modificar y codificar codigo  para encontrar maximo indice
            cliente.Id = SiguienteMayorId();

            //Agrego la estructura al XML
            AccesoADatos.Instance.data.Element("clientes").Add(new XElement("cliente",
                                        new XAttribute("id", cliente.Id.ToString().Trim()),
                                        new XElement("nombre", cliente.Nombre.ToString().Trim()),
                                        new XElement("apellido", cliente.Apellido.ToString().Trim()),
                                        new XElement("dni", cliente.DNI.ToString().Trim()),
                                        new XElement("direccion", cliente.Direccion.ToString().Trim()),
                                        new XElement("telefono", cliente.Telefono.ToString().Trim())));

            //Guardo lo ingresado a mi archivo
            AccesoADatos.Instance.GuardarXml();
            return true;
        }

        public void Borrar(string Id)
        {
            //consulto por algun campo en este caso por el atribnuto ID
            //puedo consultar por elemento también
            var consulta = from cliente in AccesoADatos.Instance.data.Descendants("cliente")
                           where cliente.Attribute("id").Value == Id
                           select cliente;
            //metodo remove borro todo el nodo
            consulta.Remove();

            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml();
        }

        public bool ExisteDni(string dni)
        {
            var consulta =
                from cliente in AccesoADatos.Instance.data.Elements("clientes").Elements("cliente")
                where (string)cliente.Element("dni") == dni.ToString()
                select new Cliente
                {
                    DNI = Convert.ToInt32(Convert.ToString(cliente.Element("dni").Value).Trim())
                };

            List<Cliente> numero = consulta.ToList();
            if (numero.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public static int SiguienteMayorId()
        {
            var maxId = AccesoADatos.Instance.data.Descendants("cliente")
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

        public int TotalClientes()
        {
            var clientes = ListarClientes();

            if (clientes != null)
            {
                return clientes.Count;
            }
            else
            {
                return 0;
            }
        }

        public bool ExisteAlquilerSala(int clienteId)
        {
            var consulta =
                from alquiler in AccesoADatos.Instance.data.Elements("alquileressala").Elements("alquilersala")
                where (string)alquiler.Element("clienteid") == clienteId.ToString()
                select new AlquilerSala
                {
                    Id = Convert.ToInt32(Convert.ToString(alquiler.Attribute("id").Value).Trim())
                };

            List<AlquilerSala> numero = consulta.ToList();
            if (numero.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool ExisteAlquilerInstrumento(int clienteId)
        {
            var listaAlquileres = AlquilerInstrumentoMap.Listar();
            if (listaAlquileres.Any(x => x.ClienteAsociado.Id == clienteId))
            {
                return true;
            }
            return false;
        }

        public static Cliente ObtenerCliente(int id)
        {
            var consulta =
                from cliente in AccesoADatos.Instance.data.Elements("clientes").Elements("cliente")
                where (string)cliente.Attribute("id") == id.ToString()
                select new Cliente
                {
                    Nombre = Convert.ToString(cliente.Element("nombre").Value).Trim(),
                    Apellido = Convert.ToString(cliente.Element("apellido").Value).Trim(),
                    DNI = Convert.ToInt32(Convert.ToString(cliente.Element("dni").Value).Trim()),
                    Id = id
                };

            List<Cliente> lista = consulta.ToList();
            foreach (var resultado in lista)
            {
                return resultado;
            }
            return null;
        }
    }
}
