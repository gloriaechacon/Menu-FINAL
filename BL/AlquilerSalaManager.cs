using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlquilerSalaManager
    {
        private readonly AlquilerSalaMap mapper;
        public AlquilerSalaManager()
        {
            mapper = new AlquilerSalaMap();
        }
        public List<AlquilerSala> Listar()
        {
            return mapper.ListarAlquileres();
        }
        public bool Guardar(AlquilerSala alquiler)
        {
            return mapper.Guardar(alquiler);
        }
        public void Borrar(string id)
        {
            mapper.Borrar(id);
        }

        public List<string> BuscarDisponibilidad(string date, int salaId)
        {
            return mapper.BuscarDisponibilidad(date, salaId);
        }

        public List<List<string>> AlquileresPorSalas()
        {
            return mapper.AlquileresPorSalas();
        }

        public List<List<string>> AlquileresPorHoras()
        {
            return mapper.AlquileresPorHoras();
        }

        public double TotalAlquileresSala()
        {
            return mapper.TotalAlquileres();
        }
    }
}
