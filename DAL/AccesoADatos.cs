using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class AccesoADatos
    {
        private readonly static AccesoADatos _instance = new AccesoADatos();
        private const string route = "XML/BaseDeDatos.XML";
        private string path = Path.Combine(Directory.GetCurrentDirectory(), route);
        public XElement data;
        public XDocument document;
        private const string esquema = "XML/BaseDeDatosEsquema.XML";
        private string esquemaPath = Path.Combine(Directory.GetCurrentDirectory(), esquema);


        public AccesoADatos()
        {
            CargarXml();
        }

        public static AccesoADatos Instance
        {
            get
            {
                return _instance;
            }
        }

        public void CargarXml()
        {
            if (File.Exists(path))
            {
                document = XDocument.Load(path);
                data = document.Element("BaseDeDatos");
            }
            else
            {
                BackupRestore.Restore(esquemaPath);
                CargarXml();
            }
        }

        public void GuardarXml()
        {
            if(document != null)
            {
                document.Save(path);
            }
        }
    }
}
