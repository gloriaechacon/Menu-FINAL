using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Composite : Componente
    {
        private IList<Componente> _hijos = new List<Componente>();

        public void AgregarHijo(Componente c)
        {
            _hijos.Add(c);
        }

        public void RemoverHijo(Componente c)
        {
            _hijos.Remove(c);
        }

        public override bool TienePermisos(string permiso)
        {
            foreach(var hijo in _hijos)
            {
                if (hijo.TienePermisos(permiso))
                {
                    return true;
                }
            }
            return false;
        }

        public void VaciarHijos()
        {
            _hijos = new List<Componente>();
        }
    }
}
