using System;
using System.Collections.Generic;
using System.IO;

namespace _01Uzduotis
{
    public class DarbasSuTextu
    {
        private readonly string _failoVieta;
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;

        public DarbasSuTextu(string failoVieta)
        {
            _failoVieta = failoVieta;
        }



        public void DarbuotojaiIFaila(List<Darbuotojas> sarasas)
        {
            _streamWriter = new StreamWriter(_failoVieta);
            foreach (Darbuotojas darbuotojas in sarasas)
            {
                _streamWriter.WriteLine($"{darbuotojas.GetId()},{darbuotojas.GetVardas()}");
            }
            _streamWriter.Close();
           
            Console.WriteLine("Darbuotoju sarasas sekmingai issaugotas i faila.");
        }

        public List<Darbuotojas> DarbuotojaiISFailo()
        {
            List<Darbuotojas> newSarasas = new List<Darbuotojas>();

            _streamReader = new StreamReader(_failoVieta);
            string eilute;
            while ((eilute = _streamReader.ReadLine()) != null)
            {
                string[] reiksmes = eilute.Split(',');
                newSarasas.Add(new Darbuotojas(int.Parse(reiksmes[0]), reiksmes[1]));
            }
            _streamReader.Close();


            Console.WriteLine("Darbuotoju sarasas sekmingai nuskaitytas is failo.");


            return newSarasas;
        }

        
    }
}
