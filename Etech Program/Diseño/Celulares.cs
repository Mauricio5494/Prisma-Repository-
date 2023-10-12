using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diseño
{
    internal class Celulares
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string CI_Cliente { get; set; }

        public string ID { get; set; }

        public override string ToString()
        {
            return "Celular: " + Marca + ", " + Modelo + " - CI del dueño " + CI_Cliente + " - ID: " + ID;
        }
    }
}
