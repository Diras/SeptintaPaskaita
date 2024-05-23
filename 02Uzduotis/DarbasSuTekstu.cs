using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Uzduotis
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

        public void ProduktaiIFaila(List<Produktas> sarasas)
        {
            _streamWriter = new StreamWriter(_failoVieta);

            foreach (Produktas produktas in sarasas)
            {
                _streamWriter.WriteLine($"{produktas.GetPavadinimas()},{produktas.GetKaina().ToString("0.00", CultureInfo.InvariantCulture)}");
            }
           
            _streamWriter.Close();
            Console.WriteLine("Produktu sarasas sekmingai issaugotas!");
        }

        public List<Produktas> ProduktaiIsFailo()
        {
            List<Produktas> sarasas = new List<Produktas>();

            _streamReader = new StreamReader(_failoVieta);
            string eilute;
            while((eilute = _streamReader.ReadLine())!= null)
            {
                string[] reiksmes = eilute.Split(',');
                sarasas.Add(new Produktas(reiksmes[0], double.Parse(reiksmes[1], CultureInfo.InvariantCulture)));
            }

            _streamReader.Close();
            Console.WriteLine("Produktu sarasas gautas is failo!");
            return sarasas;
        }
    }
}
