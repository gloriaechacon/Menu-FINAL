using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Encriptacion
    {
        public static string Encriptar(string cadena)
        {
            byte[] encrypted = Encoding.Unicode.GetBytes(cadena);
            string result = Convert.ToBase64String(encrypted);
            return result;
        }

        public static string Desencriptar(string textoEncriptado)
        {
            byte[] decrypted = Convert.FromBase64String(textoEncriptado);
            string result = Encoding.Unicode.GetString(decrypted);
            return result;
        }
    }
}
