using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AlquilerInstrumento : Alquiler
    {
        //Relacion 1 a muchos
        public List<Instrumento> InstrumentosAlquilados { get; set; }
    }
}
