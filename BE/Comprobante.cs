using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Comprobante : Entity
    {
        public string Concepto { get; set; }
        public double Monto { get; set; }
        public bool Pagado { get; set; }
        //Relacion 1 a 1
        public Alquiler Alquiler { get; set; }
    }
}
