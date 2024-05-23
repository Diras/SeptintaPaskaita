using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Uzduotis
{
    public class Preke
    {
        public Zaislas Zaislas { get; set; }
        public int Kiekis { get; set; }

        public Preke(Zaislas zaislas, int kiekis)
        {
            Zaislas = zaislas;
            Kiekis = kiekis;
        }

        public override string ToString()
        {
            return $"Prekė: {Zaislas}, Kiekis: {Kiekis}";
        }
    }
}
