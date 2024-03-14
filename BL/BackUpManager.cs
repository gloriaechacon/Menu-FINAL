using DAL;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BackUpManager
    {
        public bool BackUp(DateTime fecha)
        {
            return BackupRestore.BackUp(fecha);
        }

        public bool Restore(string archivo)
        {
            BackupRestore.Restore(archivo);
            AccesoADatos.Instance.CargarXml();
            return true;
        }

        public List<string> Listar()
        {
            return BackupRestore.ListarBackUps();
        }
    }
}
