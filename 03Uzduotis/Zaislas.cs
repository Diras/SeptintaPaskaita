using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Uzduotis
{
    public class Zaislas
    {
        public string Pavadinimas { get; set; }
        public double Kaina { get; set; }

        public Zaislas(string pavadinimas, double kaina)
        {
            Pavadinimas = pavadinimas;
            Kaina = kaina;
        }

        public override string ToString()
        {
            return $"Pavadinimas: {Pavadinimas}, Kaina: {Kaina}";
        }
    }
}
