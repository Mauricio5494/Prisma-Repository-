using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diseño
{
    internal class Tecnicos
    {
        public string ID { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return "Técnico: " + Nombre + " - ID: " + ID;
        }
    }
}
