using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diseño
{
    internal class Celulares
    {
        public string ModeloYOmarca { get; set; }

        public string Nombre_Cliente { get; set; }

        public string ID { get; set; }

        public override string ToString()
        {
            return ModeloYOmarca + " De: " + Nombre_Cliente + " - ID: " + ID;
        }
    }
}
