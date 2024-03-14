using BE.Enums;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL;

namespace Mapper
{
    public class InstrumentoMap
    {
        public List<Instrumento> ListarInstrumentos()
        {
            var leer =
                from instrumento in AccesoADatos.Instance.data.Elements("instrumentos").Elements("instrumento")
                select new Instrumento
                {
                    Id = Convert.ToInt32(Convert.ToString(instrumento.Attribute("id").Value).Trim()),
                    Codigo = Convert.ToString(instrumento.Element("codigo").Value).Trim(),
                    Nombre = Convert.ToString(instrumento.Element("nombre").Value).Trim(),
                    Descripcion = Convert.ToString(instrumento.Element("descripcion").Value).Trim(),
                    Precio = Convert.ToDouble(Convert.ToString(instrumento.Element("precio").Value).Trim())
                };
            List<Instrumento> instrumentos = leer.ToList();

            return instrumentos;
        }

        public bool Guardar(Instrumento instrumento)
        {
            if (instrumento.Id == 0) //Crear
            {
                // modificar y codificar codigo  para encontrar maximo indice
                instrumento.Id = SiguienteMayorId();

                //Agrego la estructura al XML
                AccesoADatos.Instance.data.Element("instrumentos").Add(new XElement("instrumento",
                                            new XAttribute("id", instrumento.Id.ToString().Trim()),
                                            new XElement("codigo", instrumento.Codigo.ToString().Trim()),
                                            new XElement("nombre", instrumento.Nombre.ToString().Trim()),
                                            new XElement("descripcion", instrumento.Descripcion.ToString().Trim()),
                                            new XElement("precio", instrumento.Precio.ToString().Trim())));

                //Guardo lo ingresado a mi archivo
                AccesoADatos.Instance.GuardarXml();
            }
            else //Modificar
            {
                //consulto por algun campo en este caso por el atribnuto ID
                //puedo consultar por elemento también
                var consulta = from user in AccesoADatos.Instance.data.Descendants("instrumento")
                               where user.Attribute("id").Value == instrumento.Id.ToString()
                               select user;

                //recorro la consulta y modifico el elemento de la consulta
                foreach (XElement EModifcar in consulta)
                {
                    //recorro y le paso los nuevos valores 
                    EModifcar.Element("codigo").Value = instrumento.Codigo.Trim();
                    EModifcar.Element("nombre").Value = instrumento.Nombre.Trim();
                    EModifcar.Element("descripcion").Value = instrumento.Descripcion.Trim();
                    EModifcar.Element("precio").Value = instrumento.Precio.ToString().Trim();
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
            var consulta = from instrumento in AccesoADatos.Instance.data.Descendants("instrumento")
                           where instrumento.Attribute("id").Value == Id
                           select instrumento;
            //metodo remove borro todo el nodo
            consulta.Remove();

            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml();
        }

        public bool ExisteCodigo(string codigo)
        {
            var consulta =
                from instrumento in AccesoADatos.Instance.data.Elements("instrumentos").Elements("instrumento")
                where (string)instrumento.Element("codigo") == codigo.ToString()
                select new Instrumento
                {
                    Nombre = Convert.ToString(instrumento.Element("nombre").Value).Trim()
                };

            List<Instrumento> numero = consulta.ToList();
            if (numero.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public static int SiguienteMayorId()
        {
            var maxId = AccesoADatos.Instance.data.Descendants("instrumento")
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

        public static Instrumento ObtenerInstrumento(int id)
        {
            var consulta =
                from instrumento in AccesoADatos.Instance.data.Elements("instrumentos").Elements("instrumento")
                where (string)instrumento.Attribute("id") ==id.ToString()
                select new Instrumento
                {
                    Descripcion = (instrumento.Element("descripcion").Value).Trim(),
                    Nombre = Convert.ToString(instrumento.Element("nombre").Value).Trim(),
                    Codigo = Convert.ToString(instrumento.Element("codigo").Value).Trim(),
                    Precio = Convert.ToDouble(instrumento.Element("precio").Value),
                    Id = id
                };
            return consulta.FirstOrDefault();
        }

        public bool ExisteAlquiler(int instrumentoId)
        {
            var listaAlquileres = AlquilerInstrumentoMap.Listar();
            var result = listaAlquileres.Where(x => x.InstrumentosAlquilados.Any(w=> w.Id == instrumentoId)).ToList();
            //var variable = result.Contains(instrumentoId);
            if (result.Count > 0)
            {
                return true;
            }
            return false;
        }

    }
}
