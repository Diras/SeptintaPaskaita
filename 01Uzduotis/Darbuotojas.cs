using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Uzduotis
{
    public class Darbuotojas
    {
        int Id { get; set; }
        public string Vardas { get; set; }

        public Darbuotojas()
        {

        }

        public Darbuotojas(int id, string vardas)
        {
            Id = id;
            Vardas = vardas;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id) 
        {
            Id = id;
        }

        public string GetVardas()
        {
            return Vardas;
        }

        public void SetVardas(string vardas)
        {
            Vardas = vardas;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Vardas: {Vardas}";
        }
    }
}
