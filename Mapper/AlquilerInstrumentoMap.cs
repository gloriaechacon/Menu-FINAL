using BE.Enums;
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
    public class AlquilerInstrumentoMap
    {
        private readonly InstrumentoMap instrumentoMap;
        public AlquilerInstrumentoMap()
        {
            instrumentoMap = new InstrumentoMap();
        }
        public List<AlquilerInstrumento> ListarAlquileres()
        {
            var leer =
                from alquiler in AccesoADatos.Instance.data.Elements("alquileresinstrumentos").Elements("alquilerinstrumento")
                select new AlquilerInstrumento
                {
                    Id = Convert.ToInt32(Convert.ToString(alquiler.Attribute("id").Value).Trim()),
                    Descripcion = Convert.ToString(alquiler.Element("descripcion").Value).Trim(),
                    Total = Convert.ToDouble(Convert.ToString(alquiler.Element("total").Value).Trim()),
                    Fecha = DateTime.Parse(Convert.ToString(alquiler.Element("fecha").Value.Trim())),
                    MetodoDePago = (MetodoDePago)Enum.Parse(typeof(MetodoDePago), Convert.ToString(alquiler.Element("metododepago").Value).Trim()),
                    ClienteAsociado = ObtenerCliente(Convert.ToInt32(Convert.ToString(alquiler.Element("clienteid").Value).Trim())),
                    InstrumentosAlquilados = alquiler.Elements("instrumentos").Elements("instrumentoid").Select(x => InstrumentoMap.ObtenerInstrumento(Convert.ToInt32(x.Value))).ToList()
                };
            List<AlquilerInstrumento> alquileres = leer.ToList();

            return alquileres;
        }

        public bool Guardar(AlquilerInstrumento alquiler)
        {
            if (alquiler.Id == 0) //Crear
            {
                // modificar y codificar codigo  para encontrar maximo indice
                alquiler.Id = SiguienteMayorId();

                //Agrego la estructura al XML
                AccesoADatos.Instance.data.Element("alquileresinstrumentos").Add(new XElement("alquilerinstrumento",
                                            new XAttribute("id", alquiler.Id.ToString().Trim()),
                                            new XElement("descripcion", alquiler.Descripcion.ToString().Trim()),
                                            new XElement("total", alquiler.Total.ToString().Trim()),
                                            new XElement("fecha", alquiler.Fecha.ToString("dd/MM/yyyy").Trim()),
                                            new XElement("metododepago", alquiler.MetodoDePago.ToString().Trim()),
                                            new XElement("clienteid", alquiler.ClienteAsociado.Id.ToString().Trim()),
                                            new XElement("instrumentos", alquiler.InstrumentosAlquilados.Select(x =>
                                                            new XElement("instrumentoid",x.Id)))));

                //Guardo lo ingresado a mi archivo
                AccesoADatos.Instance.GuardarXml();
            }
            else //Modificar
            {
                //consulto por algun campo en este caso por el atribnuto ID
                //puedo consultar por elemento también
                var consulta = from rent in AccesoADatos.Instance.document.Descendants("alquilerinstrumento")
                               where rent.Attribute("id").Value == alquiler.Id.ToString()
                               select rent;

                //recorro la consulta y modifico el elemento de la consulta
                foreach (XElement EModifcar in consulta)
                {
                    //recorro y le paso los nuevos valores 
                    EModifcar.Element("descripcion").Value = alquiler.Descripcion.Trim();
                    EModifcar.Element("total").Value = alquiler.Total.ToString().Trim();
                    EModifcar.Element("fecha").Value = alquiler.Fecha.ToString("dd/MM/yyyy").Trim();
                    EModifcar.Element("metododepago").Value = alquiler.MetodoDePago.ToString().Trim();
                    EModifcar.Element("clienteid").Value = alquiler.ClienteAsociado.Id.ToString().Trim();
                }

                var db = AccesoADatos.Instance.document;

                var reserva = (from alquilerModificado in db.Descendants("alquilerinstrumento")
                                           where alquilerModificado.Attribute("id").Value == alquiler.Id.ToString()
                                           select alquilerModificado).FirstOrDefault();
                var instrumentos = reserva.Element("instrumentos").Elements("instrumentoid");
                var toRemove = instrumentos.Where(x => !alquiler.InstrumentosAlquilados.Select(y => y.Id).Contains(Convert.ToInt32(x.Value)));
                var toAdd = alquiler.InstrumentosAlquilados.Where(x => !instrumentos.Select(w => Convert.ToInt32(w.Value)).Contains(x.Id)).Select(x => new XElement("instrumentoid",x.Id));


                foreach(var item in toRemove)
                {
                    item.Remove();
                }

                foreach (var item in toAdd)
                {
                    reserva.Element("instrumentos").Add(item);
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
            var consulta = from alquiler in AccesoADatos.Instance.document.Descendants("alquilerinstrumento")
                           where alquiler.Attribute("id").Value == Id
                           select alquiler;
            //metodo remove borro todo el nodo
            consulta.Remove();

            
            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml();
        }

        public static int SiguienteMayorId()
        {
            var maxId = AccesoADatos.Instance.data.Descendants("alquilerinstrumento")
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

        public List<Instrumento> ObtenerInstrumentos(int alquilerid)
        {
            var leer =
               from alquiler in AccesoADatos.Instance.data.Elements("alquileresinstrumentos").Elements("alquilerinstrumento")
               where (string)alquiler.Attribute("id") == alquilerid.ToString()
               select new AlquilerInstrumento
               {
                   InstrumentosAlquilados = alquiler.Elements("instrumentos").Elements("instrumentoid").Select(x => InstrumentoMap.ObtenerInstrumento(Convert.ToInt32(x.Value))).ToList()
               };
            var resultado = (leer.ToList()).Select(x =>x.InstrumentosAlquilados).FirstOrDefault();

            return resultado;
        }

        public static List<AlquilerInstrumento> Listar()
        {
            var leer =
                from alquiler in AccesoADatos.Instance.data.Elements("alquileresinstrumentos").Elements("alquilerinstrumento")
                select new AlquilerInstrumento
                {
                    ClienteAsociado = ClienteMap.ObtenerCliente(Convert.ToInt32(Convert.ToString(alquiler.Element("clienteid").Value).Trim())),
                    InstrumentosAlquilados = alquiler.Elements("instrumentos").Elements("instrumentoid").Select(x => InstrumentoMap.ObtenerInstrumento(Convert.ToInt32(x.Value))).ToList()
                };
            List<AlquilerInstrumento> alquileres = leer.ToList();

            return alquileres;
        }

        public double TotalAlquileres()
        {
            var alquileres = ListarAlquileres();

            if (alquileres != null)
            {
                return alquileres.Sum(item => item.Total);
            }
            else
            {
                return 0;
            }
        }

        public List<List<string>> AlquileresPorInstrumentos()
        {
            List<List<string>> listaNroReservas = new List<List<string>>();
            var alquileres = ListarAlquileres();
            var instrumentos = instrumentoMap.ListarInstrumentos();

            foreach (var instrumento in instrumentos)
            {
                List<string> objeto = new List<string>
                {
                    instrumento.Codigo,
                    instrumento.Nombre
                };
                var count = (alquileres.Select(x => x.InstrumentosAlquilados).SelectMany(w => w.Where(y => y.Id == instrumento.Id))).Count().ToString();
                objeto.Add(count);
                listaNroReservas.Add(objeto);
            }
            return listaNroReservas;
        }
    }
}
