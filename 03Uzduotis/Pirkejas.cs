using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Uzduotis
{
    public class Pirkejas
    {
        public string Vardas { get; set; }
        public List<Preke> Krepselis { get; set; }

        public Pirkejas(string vardas)
        {
            Vardas = vardas;
            Krepselis = new List<Preke>();
        }

        public override string ToString()
        {
            return $"Pirkėjas: {Vardas}";
        }
    }
}
