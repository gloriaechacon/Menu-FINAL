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
    public class SalaMap
    {
        public List<Sala> ListarSalas()
        {
            var leer =
                from sala in AccesoADatos.Instance.data.Elements("salas").Elements("sala")
                select new Sala
                {
                    Id = Convert.ToInt32(Convert.ToString(sala.Attribute("id").Value).Trim()),
                    Codigo = Convert.ToString(sala.Element("codigo").Value).Trim(),
                    Nombre = Convert.ToString(sala.Element("nombre").Value).Trim(),
                    Descripcion = Convert.ToString(sala.Element("descripcion").Value).Trim(),
                    Precio = Convert.ToDouble(Convert.ToString(sala.Element("precio").Value).Trim())
                };
            List<Sala> salas = leer.ToList();

            return salas;
        }

        public bool Guardar(Sala sala)
        {
            if (sala.Id == 0) //Crear
            {
                // modificar y codificar codigo  para encontrar maximo indice
                sala.Id = SiguienteMayorId();

                //Agrego la estructura al XML
                AccesoADatos.Instance.data.Element("salas").Add(new XElement("sala",
                                            new XAttribute("id", sala.Id.ToString().Trim()),
                                            new XElement("codigo", sala.Codigo.ToString().Trim()),
                                            new XElement("nombre", sala.Nombre.ToString().Trim()),
                                            new XElement("descripcion", sala.Descripcion.ToString().Trim()),
                                            new XElement("precio", sala.Precio.ToString().Trim())));

                //Guardo lo ingresado a mi archivo
                AccesoADatos.Instance.GuardarXml();
            }
            else //Modificar
            {
                //consulto por algun campo en este caso por el atribnuto ID
                //puedo consultar por elemento también
                var consulta = from user in AccesoADatos.Instance.data.Descendants("sala")
                               where user.Attribute("id").Value == sala.Id.ToString()
                               select user;

                //recorro la consulta y modifico el elemento de la consulta
                foreach (XElement EModifcar in consulta)
                {
                    //recorro y le paso los nuevos valores 
                    EModifcar.Element("codigo").Value = sala.Codigo.Trim();
                    EModifcar.Element("nombre").Value = sala.Nombre.Trim();
                    EModifcar.Element("descripcion").Value = sala.Descripcion.Trim();
                    EModifcar.Element("precio").Value = sala.Precio.ToString().Trim();
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
            var consulta = from sala in AccesoADatos.Instance.data.Descendants("sala")
                           where sala.Attribute("id").Value == Id
                           select sala;
            //metodo remove borro todo el nodo
            consulta.Remove();

            //despues del borrado , guardo el archivo XML para que impacte el cambio
            AccesoADatos.Instance.GuardarXml();
        }

        public bool ExisteCodigo(string codigo)
        {
            var consulta =
                from sala in AccesoADatos.Instance.data.Elements("salas").Elements("sala")
                where (string)sala.Element("codigo") == codigo.ToString()
                select new Sala
                {
                    Nombre = Convert.ToString(sala.Element("nombre").Value).Trim()
                };

            List<Sala> numero = consulta.ToList();
            if (numero.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public static int SiguienteMayorId()
        {
            var maxId = AccesoADatos.Instance.data.Descendants("sala")
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
        public bool ExisteAlquiler(int salaId)
        {
            var consulta =
                from alquiler in AccesoADatos.Instance.data.Elements("alquileressala").Elements("alquilersala")
                where (string)alquiler.Element("salaid") == salaId.ToString()
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
    }
}
