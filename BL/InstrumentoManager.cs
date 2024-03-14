using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class InstrumentoManager
    {
        private readonly InstrumentoMap mapper;
        public InstrumentoManager()
        {
            mapper = new InstrumentoMap();
        }
        public List<Instrumento> Listar()
        {
            return mapper.ListarInstrumentos();
        }
        public bool Guardar(Instrumento instrumento)
        {
            return mapper.Guardar(instrumento);
        }
        public void Borrar(string id)
        {
            mapper.Borrar(id);
        }
        public bool ExisteCodigo(string codigo)
        {
            return mapper.ExisteCodigo(codigo);
        }

        public bool ExisteAlquiler(int instrumentoId)
        {
            return mapper.ExisteAlquiler(instrumentoId);
        }
    }
}
