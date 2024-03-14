using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class BackupRestore
    {
        private const string baseDeDatos = "XML/BaseDeDatos.XML";
        private const string directorioBackUp = "BackUp";
        private static string rutaDirectorioBase = Directory.GetCurrentDirectory();
        private static string rutaFinalRestore = Path.Combine(rutaDirectorioBase, baseDeDatos);
        private static string rutaFinalBackUp = Path.Combine(rutaDirectorioBase, directorioBackUp);


        public static bool BackUp(DateTime fecha)
        {
            try
            {
                string nombreArchivo = $"BaseDeDatos-{fecha.ToString("yyyy-MM-dd-HH-mm-ss")}.XML";
                if (Directory.Exists(rutaFinalBackUp))
                {
                    if (File.Exists(rutaFinalRestore))
                    {
                        string ruta = Path.Combine(rutaFinalBackUp, nombreArchivo);
                        File.Copy(rutaFinalRestore, ruta, true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(rutaFinalBackUp);
                    BackUp(fecha);
                }
            }
            catch (Exception e) 
            {
                
            }
            return true;
        }

        public static bool Restore(string nombreArchivo)
        {
            try
            {
                if (Directory.Exists(rutaFinalBackUp))
                {
                    string rutaSeleccionada = Path.Combine(rutaFinalBackUp, nombreArchivo);
                    File.Copy(rutaSeleccionada, rutaFinalRestore, true);
                    return true;
                }
                else
                {
                    Directory.CreateDirectory(rutaFinalBackUp);
                    Restore(nombreArchivo);
                }

            }
            catch (Exception e)
            {
            }
            return false;
        }

        public static List<string> ListarBackUps()
        {
            List<string> backups = new List<string>();

            if (Directory.Exists(rutaFinalBackUp))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(rutaFinalBackUp);
                foreach (var item in directoryInfo.GetFiles())
                {
                    if (item != null)
                    {
                        backups.Add(item.Name);
                    }
                }
            }

            return backups;
        }
    }
}
