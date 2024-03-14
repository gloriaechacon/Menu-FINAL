using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SalaManager
    {
        private readonly SalaMap mapper;
        public SalaManager()
        {
            mapper = new SalaMap();
        }
        public List<Sala> Listar()
        {
            return mapper.ListarSalas();
        }
        public bool Guardar(Sala sala)
        {
            return mapper.Guardar(sala);
        }
        public void Borrar(string id)
        {
            mapper.Borrar(id);
        }
        public bool ExisteCodigo(string codigo)
        {
            return mapper.ExisteCodigo(codigo);
        }
        public bool ExisteAlquiler(int salaId)
        {
            return mapper.ExisteAlquiler(salaId);
        }
    }
}
