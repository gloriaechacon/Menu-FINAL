using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlquilerInstrumentoManager
    {
        private readonly AlquilerInstrumentoMap mapper;
        public AlquilerInstrumentoManager()
        {
            mapper = new AlquilerInstrumentoMap();
        }
        public List<AlquilerInstrumento> Listar()
        {
            return mapper.ListarAlquileres();
        }
        public bool Guardar(AlquilerInstrumento alquiler)
        {
            return mapper.Guardar(alquiler);
        }
        public void Borrar(string id)
        {
            mapper.Borrar(id);
        }
        public List<Instrumento> ObtenerInstrumentos(int alquilerid)
        {
            return mapper.ObtenerInstrumentos(alquilerid);
        }
        public double TotalAlquileresInstrumentos()
        {
            return mapper.TotalAlquileres();
        }

        public List<List<string>> AlquileresPorInstrumentos()
        {
            return mapper.AlquileresPorInstrumentos();
        }
    }
}
