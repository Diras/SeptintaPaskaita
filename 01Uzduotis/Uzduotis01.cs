using _01Uzduotis;
using System;

namespace SeptintaPaskaita
{
    public class Uzduotis01 
    {
        /*
         * Užduotis 1: Sukurkite programą, kuri valdo darbuotojų duomenis. 
         * Programa leis pridėti darbuotojus, rodyti visus darbuotojus ir išsaugoti bei nuskaityti darbuotojų duomenis iš failo.
            Pridėti darbuotoją į sąrašą
            Pašalinti darbuotoją iš sąrašo
            Parodyti visus darbuotojus
         * */
        public static void Main(string[] args)
        {
            List<Darbuotojas> darbuotojuSarasas = new List<Darbuotojas>();
            DarbasSuTextu DarbotojaiText = new DarbasSuTextu("darbuotojai.txt");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Darbuotoju valdymo preograma Ver.01");
                Console.WriteLine("1. Prideti darbuotoja");
                Console.WriteLine("2. Pasalinti darbuotoja");
                Console.WriteLine("3. Rodyti visus darbuotojus");
                Console.WriteLine("4. Issaugoti darbuotojų saraša i faila");
                Console.WriteLine("5. Nuskaityti darbuotoju saraša iš failo");
                Console.WriteLine("6. Iseiti");
                Console.Write("Pasirinkite veiksma: ");

                int pasirinkimas = CheckInput(1,6);

                switch (pasirinkimas)
                {
                    case 1:
                        PridetiDarbuotoja(darbuotojuSarasas);
                        break;
                    case 2:
                        PasalintiDarbuotoja(darbuotojuSarasas);
                        break;
                    case 3:
                        RodytiVisusDarbuotojus(darbuotojuSarasas);
                        break;
                    case 4:
                        DarbotojaiText.DarbuotojaiIFaila(darbuotojuSarasas);
                        break;
                    case 5:
                        darbuotojuSarasas = DarbotojaiText.DarbuotojaiISFailo();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas. Bandykite dar karta.");
                        break;
                }

                Console.WriteLine("Paspauskite bet ka, kad testumete...");
                Console.ReadKey();
            }
        }


        static int CheckInput()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Neteisingas skaicius, pabandykite dar karta!");
            }
            return number;
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
                    Console.WriteLine("Neteisingas skaicius, pabandykite dar karta!");
                }
            }
        }

        static void PridetiDarbuotoja(List<Darbuotojas> sarasas)
        {
            Console.Write("Iveskite darbuotojo ID (skaicius): ");
            int id = CheckInput();

            foreach (Darbuotojas darbuotojas in sarasas)
            {
                if(darbuotojas.GetId() == id)
                {
                    Console.WriteLine("Darbuotojas su tokiu ID jau yra!");
                    Console.WriteLine("Bandykite is naujo!");
                    return;
                }
            }

            Console.Write("Iveskite darbuotojo varda: ");
            string vardas = Console.ReadLine();

            sarasas.Add(new Darbuotojas(id, vardas));
            Console.WriteLine("Darbuotojas pridėtas sėkmingai.");
        }

        static void PasalintiDarbuotoja(List<Darbuotojas> sarasas)
        {

            Console.Write("Įveskite darbuotojo ID, kurį norite pašalinti: ");
            int id = int.Parse(Console.ReadLine());

            Darbuotojas darbuotojasKuriTrinsiu = null;
            foreach (Darbuotojas darbuotojas in sarasas)
            {
                if(darbuotojas.GetId() == id)
                {
                    darbuotojasKuriTrinsiu = darbuotojas;
                    break;
                }
            }


            if (darbuotojasKuriTrinsiu != null)
            {
                sarasas.Remove(darbuotojasKuriTrinsiu);
                Console.WriteLine("Darbuotojas pašalintas sėkmingai.");
            }
            else
            {
                Console.WriteLine("Darbuotojas su tokiu ID nerastas.");
            }
        }

        static void RodytiVisusDarbuotojus(List<Darbuotojas> sarasas)
        {
            if (sarasas.Count == 0)
            {
                Console.WriteLine("Darbuotoju sarasas tuscias!");
            }
            else
            {
                foreach (Darbuotojas darbuotojas in sarasas)
                {
                    Console.WriteLine(darbuotojas.ToString());
                }
            }
        }
    }
    

}