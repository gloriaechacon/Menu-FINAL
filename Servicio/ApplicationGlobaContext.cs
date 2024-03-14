using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ApplicationGlobalContext
    {
        private readonly static ApplicationGlobalContext _instance = new ApplicationGlobalContext();
        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }
        public Composite AccessControl = new Composite();
        public static ApplicationGlobalContext Instance
        {
            get
            {
                return _instance;
            }
        }

        public bool IsLoggedIn()
        {
            return Usuario != null;
        }
    }
}
