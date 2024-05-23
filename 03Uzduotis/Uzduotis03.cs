using _03Uzduotis;
using System;

namespace SeptintaPaskaita
{
    public class Uzduotis03 
    {
        /*
         * Užduotis: Produktų katalogo valdymo sistema
            Sukurkite programą, kuri valdo produktų katalogą. Programa leis atlikti šias operacijas:
            Pridėti naują produktą.
            Rodyti visus produktus.
            Pridėti pirkėją.
            Atnaujinti produkto informaciją.
            Pirkti - pasirinkti pirkėja, pasirinkti produktą ir išrašyti kvitą į naują txt failą
            Išsaugoti ir nuskaityti produktų duomenis iš failo.
            Klases:
            Zaislas - Pavadinimas (string), Kaina(decimal)
            Pirkinių krepšelio Prekė - Žaislas ir kiekis (int)
            Pirkėjas - Vardas, krepšelio prekių sąrašas
         * */
        static void Main(string[] args)
        {
            List<Zaislas> zaisluKatalogas = new List<Zaislas>();
            List<Pirkejas> pirkejuSarasas = new List<Pirkejas>();
            string failoVieta = "produktai.txt";
            string cekioVieta = "cekis.txt";
            DarbasSuTekstu darbasSuTekstu = new DarbasSuTekstu(failoVieta);
            DarbasSuTekstu cakioIsdavimas = new DarbasSuTekstu(cekioVieta);
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Produktų katalogo valdymo sistema");
                Console.WriteLine("1. Pridėti naują produktą");
                Console.WriteLine("2. Rodyti visus produktus");
                Console.WriteLine("3. Pridėti pirkėją");
                Console.WriteLine("4. Atnaujinti produkto informaciją");
                Console.WriteLine("5. Pirkti");
                Console.WriteLine("6. Išsaugoti produktų sąrašą į failą");
                Console.WriteLine("7. Nuskaityti produktų sąrašą iš failo");
                Console.WriteLine("8. Išeiti");

                int pasirinkimas = CheckInput(1, 8);

                switch (pasirinkimas)
                {
                    case 1:
                        PridetiNaujaProdukta(zaisluKatalogas);
                        break;
                    case 2:
                        RodytiVisusProduktus(zaisluKatalogas);
                        break;
                    case 3:
                        PridetiPirkeja(pirkejuSarasas);
                        break;
                    case 4:
                        AtnaujintiProduktoInformacija(zaisluKatalogas);
                        break;
                    case 5:
                        Pirkti(pirkejuSarasas, zaisluKatalogas, cakioIsdavimas);
                        break;
                    case 6:
                        darbasSuTekstu.ProduktaiIFaila(zaisluKatalogas);
                        break;
                    case 7:
                        zaisluKatalogas = darbasSuTekstu.ProduktaiIsFailo();
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas. Bandykite dar kartą.");
                        break;
                }

                Console.WriteLine("Paspauskite bet ką, kad testumėte...");
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



        static double CheckInputKaina()
        {
            double kaina;
            while (true)
            {
                Console.Write("Įveskite kainą: ");
                if (double.TryParse(Console.ReadLine(), out kaina) && kaina >= 0)
                {
                    return kaina;
                }
                else
                {
                    Console.WriteLine("Neteisingas formatas. Įveskite kainą iš naujo.");
                    if(kaina < 0)
                    {
                        Console.WriteLine("Negali buti maziau 0!");
                    }
                }
            }
        }

        static void PridetiNaujaProdukta(List<Zaislas> sarasas)
        {
            Console.Write("Įveskite zaislo pavadinimą: ");
            string pavadinimas = Console.ReadLine();

            double kaina = CheckInputKaina();

            if (sarasas.Count > 0)
            {
                foreach (Zaislas zaislas in sarasas)
                {
                    if (zaislas.Pavadinimas.ToLower() == pavadinimas.ToLower())
                    {
                        Console.WriteLine("Produktas su tokiu pavadinimu YRA!");
                        Console.WriteLine("Bandykite is naujo!");
                        return;
                    }
                }
            }

            sarasas.Add(new Zaislas(pavadinimas, kaina));
            Console.WriteLine("Produktas pridėtas sėkmingai!");
            Console.WriteLine();
        }

        static void RodytiVisusProduktus(List<Zaislas> sarasas)
        {
            if (sarasas.Count == 0)
            {
                Console.WriteLine("Produktų sąrašas tuščias!");
            }
            else
            {
                foreach (Zaislas zaislas in sarasas)
                {
                    Console.WriteLine(zaislas.ToString());
                }
            }
        }

        static void PridetiPirkeja(List<Pirkejas> sarasas)
        {
            Console.Write("Įveskite pirkėjo vardą: ");
            string vardas = Console.ReadLine();

            if (sarasas.Count > 0)
            {
                foreach (Pirkejas pirkejas in sarasas)
                {
                    if (pirkejas.Vardas.ToLower() == vardas.ToLower())
                    {
                        Console.WriteLine("Produktas su tokiu vardu YRA!");
                        Console.WriteLine("Bandykite is naujo!");
                        return;
                    }
                }
            }
            sarasas.Add(new Pirkejas(vardas));
            Console.WriteLine("Pirkėjas pridėtas sėkmingai!");
        }

        static void AtnaujintiProduktoInformacija(List<Zaislas> sarasas)
        {
            Console.WriteLine("Zaislu sarasas:");
            RodytiVisusProduktus(sarasas);
            Console.WriteLine();

            Console.WriteLine("Iveskite zaislo pavadinima kuri norite atnaujinti: ");
            string pavadinimas = Console.ReadLine();

            Zaislas produktasKuriAtnaujinsiu = null;
            foreach (Zaislas produktas in sarasas)
            {
                if (produktas.Pavadinimas.ToLower() == pavadinimas.ToLower())
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

                produktasKuriAtnaujinsiu.Pavadinimas = pavadinimasNaujas;
                produktasKuriAtnaujinsiu.Kaina = kainaNauja;

                Console.WriteLine("Produkto informacija atnaujinta sėkmingai.");
            }
            else
            {
                Console.WriteLine("Produktas nerastas!");
            }
        }

        static void Pirkti(List<Pirkejas> pirkejuSarasas, List<Zaislas> zaisluSarasas, DarbasSuTekstu cekioIsdavimas )
        {
            Console.WriteLine("Pirkeju sarasas:");
            if(pirkejuSarasas.Count == 0)
            {
                Console.WriteLine("Sarase nera pirkeju!");
                return;
            }

            foreach (Pirkejas pirkejas in pirkejuSarasas)
            {
                Console.WriteLine(pirkejas);
            }
            Console.WriteLine();
            Console.WriteLine("Iveskite pirkejo varda kas perka...");
            string pirkejoVardas = Console.ReadLine();

            Pirkejas pirkejas1 = null;
            foreach (Pirkejas pirkejas in pirkejuSarasas)
            {
                if(pirkejas.Vardas.ToLower() == pirkejoVardas.ToLower())
                {
                    pirkejas1 = pirkejas;
                    break;
                }
            }

            if ( pirkejas1 == null )
            {
                Console.WriteLine("Tokio pirkejo nera, bandykite is naujo!");
                Console.WriteLine();
                return;
            }
            


            while (true) 
            {
                Console.Clear();
                Console.WriteLine($"Pasirinktas pirkejas: {pirkejas1}");
                Console.WriteLine();
                Console.WriteLine("Produktu sarasas:");
                RodytiVisusProduktus(zaisluSarasas);
                Console.WriteLine();
                Console.WriteLine("Iveskite produkto pavadinima, kuri norite nupirkti...");

                Zaislas zaislas1 = null;
                string zaisloPavadinimas = Console.ReadLine();

                foreach (Zaislas zaislas in zaisluSarasas)
                {
                    if (zaislas.Pavadinimas.ToLower() == zaisloPavadinimas)
                    {
                        zaislas1 = zaislas;
                        break;
                    }
                }

                if (zaislas1 == null)
                {
                    Console.WriteLine("Tokio produkto nera, bandykite is naujo!");
                    Console.WriteLine();
                    return;
                }

                Console.Clear();
                Console.WriteLine($"Pasirinktas pirkejas: {pirkejas1}");
                Console.WriteLine();
                Console.WriteLine($"Pasirinktas produktas: {zaislas1}");
                Console.WriteLine();
                Console.WriteLine("Iveskite produkto kieki, kiek nirite nupirkti...");
                int kiekis = CheckInput(0, int.MaxValue);

                pirkejas1.Krepselis.Add(new Preke(zaislas1, kiekis));

                Console.WriteLine();
                Console.WriteLine("Paspauskite 1. Jeigu norite pirkti toliui ");
                Console.WriteLine("Paspauskite 2. Jeigu norite baigti");
                int number = CheckInput(1,2);
                if (number == 1)
                {
                    
                }
                else if (number == 2)
                {
                    break;
                }
            }

           
            cekioIsdavimas.ProduktaiIKvita(pirkejas1.Krepselis);
            Console.WriteLine("Pirkimas atliktas, cekis issaugotas!");


        } 
    }

}