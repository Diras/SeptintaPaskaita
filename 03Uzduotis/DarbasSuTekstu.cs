using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Uzduotis
{
    public class DarbasSuTekstu
    {
        private readonly string _failoVieta;

        private StreamReader _streamReader;
        private StreamWriter _streamWriter;



        public DarbasSuTekstu()
        {

        }

        public DarbasSuTekstu(string failoVieta)
        {
            _failoVieta = failoVieta;
        }

        public void ProduktaiIFaila(List<Zaislas> sarasas)
        {
            _streamWriter = new StreamWriter(_failoVieta);

            foreach (Zaislas produktas in sarasas)
            {
                _streamWriter.WriteLine($"{produktas.Pavadinimas},{produktas.Kaina.ToString("0.00", CultureInfo.InvariantCulture)}");
            }

            _streamWriter.Close();
            Console.WriteLine("Produktu sarasas sekmingai issaugotas!");
        }

        public List<Zaislas> ProduktaiIsFailo()
        {
            List<Zaislas> sarasas = new List<Zaislas>();

            if (!File.Exists(_failoVieta))
            {
                Console.WriteLine("Failas nerastas. Grąžinamas tuščias sąrašas.");
                return sarasas;
            }

            _streamReader = new StreamReader(_failoVieta);
            string eilute;
            while ((eilute = _streamReader.ReadLine()) != null)
            {
                string[] reiksmes = eilute.Split(',');
                sarasas.Add(new Zaislas(reiksmes[0], double.Parse(reiksmes[1], CultureInfo.InvariantCulture)));
            }

            _streamReader.Close();
            Console.WriteLine("Produktu sarasas gautas is failo!");
            return sarasas;
        }


        public void ProduktaiIKvita(List<Preke> sarasas)
        {
            _streamWriter = new StreamWriter(_failoVieta);
            double sum = 0;
            foreach (Preke preke in sarasas)
            {
                string zaisloString = $"Zaislas {preke.Zaislas.Pavadinimas}, Kaina: {preke.Zaislas.Kaina.ToString("0.00", CultureInfo.InvariantCulture)}";
                sum += preke.Zaislas.Kaina * preke.Kiekis;

                _streamWriter.WriteLine($"{zaisloString}, Kiekis: {preke.Kiekis}");
            }

            _streamWriter.WriteLine($"Bendra suma:{sum.ToString("0.00", CultureInfo.InvariantCulture)} \nAciu kad perkate pas mus!");
            
            _streamWriter.Close();
            Console.WriteLine("Produktu sarasas sekmingai issaugotas!");
        }

        
    }
}
