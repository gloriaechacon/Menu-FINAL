using BE;
using BE.Enums;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Xml.Linq;

namespace Mapper
{
    public class AlquilerSalaMap
    {
        private readonly SalaMap salaMap;
        public AlquilerSalaMap()
        {
            salaMap = new SalaMap();
        }
        public List<AlquilerSala> ListarAlquileres()
        {
            var leer =
                from alquiler in AccesoADatos.Instance.data.Elements("alquileressala").Elements("alquilersala")
                select new AlquilerSala
                {
                    Id = Convert.ToInt32(Convert.ToString(alquiler.Attribute("id").Value).Trim()),
                    Descripcion = Convert.ToString(alquiler.Element("descripcion").Value).Trim(),
                    Total = Convert.ToDouble(Convert.ToString(alquiler.Element("total").Value).Trim()),
                    Fecha = DateTime.Parse(Convert.ToString(alquiler.Element("fecha").Value.Trim())),
                    Hora = Convert.ToString(alquiler.Element("hora").Value).Trim(),
                    MetodoDePago = (MetodoDePago)Enum.Parse(typeof(MetodoDePago), Convert.ToString(alquiler.Element("metododepago").Value).Trim()),
                    ClienteAsociado = ObtenerCliente(Convert.ToInt32(Convert.ToString(alquiler.Element("clienteid").Value).Trim())),
                    SalaAlquilada = ObtenerSala(Convert.ToInt32(Convert.ToString(alquiler.Element("salaid").Value).Trim()))
                };
            List<AlquilerSala> alquileres = leer.ToList();

            return alquileres;
        }

        public bool Guardar(AlquilerSala alquiler)
        {
            if (alquiler.Id == 0) //Crear
            {
                // modificar y codificar codigo  para encontrar maximo indice
                alquiler.Id = SiguienteMayorId();

                //Agrego la estructura al XML
                AccesoADatos.Instance.data.Element("alquileressala").Add(new XElement("alquilersala",
                                            new XAttribute("id", alquiler.Id.ToString().Trim()),
                                            new XElement("descripcion", alquiler.Descripcion.ToString().Trim()),
                                            new XElement("total", alquiler.Total.ToString().Trim()),
                                            new XElement("fecha", alquiler.Fecha.ToString("dd/MM/yyyy").Trim()),
                                            new XElement("hora", alquiler.Hora.ToString().Trim()),
                                            new XElement("metododepago", alquiler.MetodoDePago.ToString().Trim()),
                                            new XElement("clienteid", alquiler.ClienteAsociado.Id.ToString().Trim()),
                                            new XElement("salaid", alquiler.SalaAlquilada.Id.ToString().Trim())));

                //Guardo lo ingresado a mi archivo
                AccesoADatos.Instance.GuardarXml();
            }
            else //Modificar
            {
                //consulto por algun campo en este caso por el atribnuto ID
                //puedo consultar por elemento también
                var consulta = from rent in AccesoADatos.Instance.data.Descendants("alquilersala")
                               where rent.Attribute("id").Value == alquiler.Id.ToString()
                               select rent;

                //recorro la consulta y modifico el elemento de la consulta
                foreach (XElement EModifcar in consulta)
                {
                    //recorro y le paso los nuevos valores 
                    EModifcar.Element("descripcion").Value = alquiler.Descripcion.Trim();
                    EModifcar.Element("total").Value = alquiler.Total.ToString().Trim();
                    EModifcar.Element("fecha").Value = alquiler.Fecha.ToString("dd/MM/yyyy").Trim();
                    EModifcar.Element("hora").Value = alquiler.Hora.ToString().Trim();
                    EModifcar.Element("metododepago").Value = alquiler.MetodoDePago.ToString().Trim();
                    EModifcar.Element("clienteid").Value = alquiler.ClienteAsociado.Id.ToString().Trim();
                    EModifcar.Element("salaid").Value = alquiler.SalaAlquilada.Id.ToString().Trim();
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
            var consulta = from alquiler in AccesoADatos.Instance.data.Descendants("alquilersala")
                           where alquiler.Attribute("id").Value == Id
                           select alquiler;
            //metodo remove borro todo el nodo
            consulta.Remove();

            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml();
        }

        public static int SiguienteMayorId()
        {
            var maxId = AccesoADatos.Instance.data.Descendants("alquilersala")
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

        public Cliente ObtenerCliente(int id)
        {
            var consulta =
                from cliente in AccesoADatos.Instance.data.Elements("clientes").Elements("cliente")
                where (string)cliente.Attribute("id") == id.ToString()
                select new Cliente
                {
                    Nombre = Convert.ToString(cliente.Element("nombre").Value).Trim(),
                    Apellido = Convert.ToString(cliente.Element("apellido").Value).Trim(),
                    DNI = Convert.ToInt32(Convert.ToString(cliente.Element("dni").Value).Trim())
                };


            List<Cliente> lista = consulta.ToList();
            foreach (var resultado in lista)
            {
                return resultado;
            }
            return null;
        }

        public Sala ObtenerSala(int id)
        {
            var consulta =
                from sala in AccesoADatos.Instance.data.Elements("salas").Elements("sala")
                where (string)sala.Attribute("id") == id.ToString()
                select new Sala
                {
                    Codigo = Convert.ToString(sala.Element("codigo").Value).Trim(),
                    Nombre = Convert.ToString(sala.Element("nombre").Value).Trim(),

                };


            List<Sala> lista = consulta.ToList();
            foreach (var resultado in lista)
            {
                return resultado;
            }
            return null;
        }

        public List<string> BuscarDisponibilidad(string date, int salaId)
        {
            var consulta =
                from alquiler in AccesoADatos.Instance.data.Elements("alquileressala").Elements("alquilersala")
                where (string)alquiler.Element("salaid") == salaId.ToString() && (string)alquiler.Element("fecha") == date
                select new AlquilerSala
                {
                    Hora = Convert.ToString(alquiler.Element("hora").Value).Trim()
                };

            List<AlquilerSala> alquileres = consulta.ToList();
            var horas = new List<string>() { "9:00", "13:00", "18:00"};

            foreach(var alquiler in alquileres)
            {
                var tieneHorario = horas.Any(x => x == alquiler.Hora);
                if (tieneHorario)
                {
                    horas.Remove(alquiler.Hora);
                }
            }
            return horas;
        }

        public List<List<string>> AlquileresPorSalas()
        {
            List<List<string>> listaNroReservas = new List<List<string>>();
            var alquileres = ListarAlquileres();
            var salas = salaMap.ListarSalas();

            foreach(var sala in salas)
            {
                List<string> objeto = new List<string>
                {
                    sala.Codigo,
                    sala.Nombre
                };
                var count = (alquileres.Select(x => x.SalaAlquilada).Where(x => x.Codigo == sala.Codigo)).Count().ToString();
                objeto.Add(count);
                listaNroReservas.Add(objeto);
            }
            return listaNroReservas;
        }

        public List<List<string>> AlquileresPorHoras()
        {
            List<List<string>> listaNroReservas = new List<List<string>>();
            var alquileres = ListarAlquileres();
            var horas = new List<string>() { "9:00", "13:00", "18:00" };

            foreach (var hora in horas)
            {
                List<string> objeto = new List<string>
                {
                    hora
                };
                var count = (alquileres.Select(x => x.Hora).Where(x => x == hora)).Count().ToString();
                objeto.Add(count);
                listaNroReservas.Add(objeto);
            }
            return listaNroReservas;
        }

        public double TotalAlquileres()
        {
            var alquileres = ListarAlquileres();

            if(alquileres != null)
            {
                return alquileres.Sum(item => item.Total);
            }
            else
            {
                return 0;
            }
        }
    }
}
