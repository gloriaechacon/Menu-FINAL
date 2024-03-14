using BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Alquiler : Entity
    {
        //Defino propiedades de la clase
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public Cliente ClienteAsociado { get; set; }
    }
}
