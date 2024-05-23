using _02Uzduotis;
using System;

namespace SeptintaPaskaita
{
    public class Uzduotis02
    {
        /*
         * Užduotis 2: Produktų katalogo valdymo sistema
            Sukurkite programą, kuri valdo produktų katalogą. Programa leis atlikti šias operacijas:
            Pridėti naują produktą.
            Rodyti visus produktus.
            Ieškoti produkto pagal pavadinimą.
            Atnaujinti produkto informaciją.
            Ištrinti produktą.
            Išsaugoti ir nuskaityti produktų duomenis iš failo.
         * */
        static void Main(string[] args)
        {
            List<Produktas> produktuSarasas = new List<Produktas>();
            DarbasSuTekstu tekstas = new DarbasSuTekstu("produktai.txt");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Produktu katalogo valdymo programa Ver.01");
                Console.WriteLine("1. Pridėti naują produktą");
                Console.WriteLine("2. Rodyti visus produktus");
                Console.WriteLine("3. Ieškoti produkto pagal pavadinimą");
                Console.WriteLine("4. Atnaujinti produkto informaciją");
                Console.WriteLine("5. Ištrinti produktą");
                Console.WriteLine("6. Išsaugoti produktų sąrašą į failą");
                Console.WriteLine("7. Nuskaityti produktų sąrašą iš failo");
                Console.WriteLine("8. Išeiti");
                Console.Write("Pasirinkite veiksmą: ");

                int pasirinkimas = CheckInput(1, 8);

                switch (pasirinkimas)
                {
                    case 1:
                        PridetiProdukta(produktuSarasas);
                        break;
                    case 2:
                        RodytiVisusProduktus(produktuSarasas);
                        break;
                    case 3:
                        IeskotiProdukta(produktuSarasas);
                        break;
                    case 4:
                        AtnaujintiProdukta(produktuSarasas);
                        break;
                    case 5:
                        PasalintiProdukta(produktuSarasas);
                        break;
                    case 6:
                        tekstas.ProduktaiIFaila(produktuSarasas);
                        break;
                    case 7:
                        produktuSarasas = tekstas.ProduktaiIsFailo();
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas. Bandykite dar kartą.");
                        break;
                }

                Console.WriteLine("Paspauskite bet kurį klavišą, kad tęstumėte...");
                Console.ReadKey();
            }
        }

        static int CheckInput(int nuo, int iki)
        {
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number) && number >= nuo && number <= iki)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Neteisingas skaičius, pabandykite dar kartą!");
                }
            }
        }

        static double CheckInput()
        {
            double kaina;
            while (true)
            {
                Console.Write("Įveskite kainą: ");
                if (double.TryParse(Console.ReadLine(), out kaina))
                {
                    return kaina;
                }
                else
                {
                    Console.WriteLine("Neteisingas formatas. Įveskite kainą iš naujo.");
                }
            }
        }

        static void PridetiProdukta(List<Produktas> sarasas)
        {
            Console.Write("Įveskite produkto pavadinimą: ");
            string pavadinimas = Console.ReadLine();

            Console.Write("Įveskite produkto kainą: ");
            double kaina = CheckInput();

            if(sarasas.Count > 0)
            {
                foreach (Produktas produktas in sarasas)
                {
                    if(produktas.GetPavadinimas().ToLower() == pavadinimas && produktas.GetKaina() == kaina)
                    {
                        Console.WriteLine("Produktas su tokiu pavadinimu ir kaina jau YRA!");
                        Console.WriteLine("Bandykite is naujo!");
                        return;
                    }
                }
            }

            sarasas.Add(new Produktas(pavadinimas, kaina));
            Console.WriteLine("Produktas pridėtas sėkmingai!");
            Console.WriteLine();
        }

        static void RodytiVisusProduktus(List<Produktas> sarasas)
        {
            if (sarasas.Count == 0)
            {
                Console.WriteLine("Produktų sąrašas tuščias!");
            }
            else
            {
                foreach (Produktas produktas in sarasas)
                {
                    Console.WriteLine(produktas.ToString());
                }
            }
        }

        static void IeskotiProdukta(List<Produktas> sarasas)
        {
            Console.Write("Įveskite produkto pavadinimą arba jo dali, kuri norite surasti: ");
            string pavadinimas = Console.ReadLine().ToLower();

            foreach (Produktas produktas in sarasas)
            {
                if (produktas.GetPavadinimas().ToLower().Contains(pavadinimas.ToLower()))
                {
                    Console.WriteLine(produktas.ToString());
                }
            }
        }

        static void AtnaujintiProdukta(List<Produktas> sarasas)
        {
            Console.WriteLine("Produktu sarasas:");
            RodytiVisusProduktus(sarasas);
            Console.WriteLine();

            Console.WriteLine("Iveskite produkto pavadinima kuri norite atnaujinti: ");
            string pavadinimas = Console.ReadLine();

            Produktas produktasKuriAtnaujinsiu = null;
            foreach (Produktas produktas in sarasas)
            {
                if (produktas.GetPavadinimas().ToLower() == pavadinimas.ToLower())
                {
                    produktasKuriAtnaujinsiu = produktas;
                    break;
                }
            }

            if (produktasKuriAtnaujinsiu != null)
            {
                Console.Write("Įveskite naują produkto pavadinimą: ");
                string pavadinimasNaujas = Console.ReadLine();
                Console.Write("Įveskite naują produkto kainą: ");

                double kainaNauja = double.Parse(Console.ReadLine());

                produktasKuriAtnaujinsiu.SetPavadinimas(pavadinimasNaujas);
                produktasKuriAtnaujinsiu.SetKaina(kainaNauja);

                Console.WriteLine("Produkto informacija atnaujinta sėkmingai.");
            }
            else
            {
                Console.WriteLine("Produktas nerastas!");
            }
        }

        static void PasalintiProdukta(List<Produktas> sarasas)
        {
            Console.WriteLine("Produktu sarasas:");
            RodytiVisusProduktus(sarasas);
            Console.WriteLine();

            Console.WriteLine("Iveskite produkto pavadinima kuri norite istrinti: ");
            string pavadinimas = Console.ReadLine();

            Produktas produktasKuriTrinsiu = null;
            foreach (Produktas produktas in sarasas)
            {
                if (produktas.GetPavadinimas().ToLower() == pavadinimas.ToLower())
                {
                    produktasKuriTrinsiu = produktas;
                    break;
                }
            }

            if (produktasKuriTrinsiu != null)
            {
                sarasas.Remove(produktasKuriTrinsiu);
                Console.WriteLine("Produktas pašalintas sėkmingai.");
            }
            else
            {
                Console.WriteLine("Produktas nerastas.");
            }
        }
    }


}