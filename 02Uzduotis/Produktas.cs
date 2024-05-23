using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Uzduotis
{
    public class Produktas
    {
        
        string Pavadinimas { get; set; }
        double Kaina { get; set; }

        public Produktas() 
        { 

        }

        public Produktas( string pavadinimas, double kaina)
        {
            Pavadinimas = pavadinimas;
            Kaina = kaina;
        }

        public string GetPavadinimas()
        {
            return Pavadinimas;
        }

        public void SetPavadinimas(string pavadinimas)
        {
            Pavadinimas= pavadinimas;
        }

        public double GetKaina()
        {
            return Kaina;
        }

        public void SetKaina(double kaina)
        {
            Kaina= kaina;
        }


        public override string ToString()
        {
            return $"Pavadinimas: {Pavadinimas}, Kaina: {Kaina}";
        }
    }
}
