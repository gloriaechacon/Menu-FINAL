using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AlquilerSala : Alquiler
    {
        public string Hora { get; set; }
        //Relacion 1 a 1
        public Sala SalaAlquilada { get; set; }
    }
}
