using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;

namespace OSA5
{

    class Program
    {
        static void Main()
        {
            // животные------------------------------------------------------------------
            List<Loom> loomad = new List<Loom>();
            Console.WriteLine("Sisesta andmed vähemalt 5 lemmiku kohta: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Lemmiku {i + 1} nimi: ");
                string nimi = Console.ReadLine();

                string liik = "";
                while (liik != "kass" && liik != "koer")
                {
                    Console.Write("Liik (kass или koer): ");
                    liik = Console.ReadLine().ToLower();
                    if (liik != "kass" && liik != "koer")
                        Console.WriteLine("Vigane liik! Palun sisesta 'kass' või 'koer'.");
                }

                int vanus;
                while (true)
                {
                    Console.Write("Vanus: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out vanus) && vanus >= 0)
                        break;
                    else
                        Console.WriteLine("Vigane vanus! Palun sisesta positiivne täisarv.");
                }

                loomad.Add(new Loom(nimi, liik, vanus));
                Console.WriteLine();
            }

            KuvadaKassid(loomad);
            double keskmine = KeskmineVanus(loomad);
            Console.WriteLine($"\nLoomade keskmine vanus: {keskmine:F1} aastat");

            Loom vanim = VanimLoom(loomad);
            Console.WriteLine($"Kõige vanem loom on {vanim.Nimi} ({vanim.Liik}), {vanim.Vanus} aastat vana");

            Console.Write("\nSisesta otsitava looma nimi: ");
            string otsing = Console.ReadLine();
            OtsiNimeJargi(loomad, otsing);

            static void KuvadaKassid(List<Loom> loomad)
            {
                Console.WriteLine("\nKõik kassid:");
                foreach (var loom in loomad)
                {
                    if (loom.Liik == "kass")
                        Console.WriteLine($"{loom.Nimi}, {loom.Vanus} aastat");
                }
            }

            static double KeskmineVanus(List<Loom> loomad)
            {
                return loomad.Average(l => l.Vanus);
            }

            static Loom VanimLoom(List<Loom> loomad)
            {
                return loomad.OrderByDescending(l => l.Vanus).First();
            }

            static void OtsiNimeJargi(List<Loom> loomad, string nimi)
            {
                var leitud = loomad.FirstOrDefault(l => l.Nimi.Equals(nimi, StringComparison.OrdinalIgnoreCase));
                if (leitud != null)
                    Console.WriteLine($"Leitud: {leitud.Nimi} ({leitud.Liik}), {leitud.Vanus} aastat");
                else
                    Console.WriteLine("Loom ei leitud.");
            }

            // валюта -----------------------------------------
            List<Valyuta> valyuty = new List<Valyuta>
            {
                new Valyuta("USD", 1.1),
                new Valyuta("GBP", 0.85),
                new Valyuta("JPY", 130),
                new Valyuta("EUR", 1)
            };

            Console.WriteLine("\nSisesta summa ja valuuta (nt: 100 USD):");
            string[] sisend = Console.ReadLine().Split();
            if (sisend.Length != 2)
            {
                Console.WriteLine("Vigane sisend!");
                return;
            }

            double summa;
            while (!double.TryParse(sisend[0], out summa) || summa < 0)
            {
                Console.WriteLine("Vigane summa! Palun sisesta positiivne number.");
                sisend = Console.ReadLine().Split();
            }

            string valName = sisend[1].ToUpper();
            Valyuta valyuta = valyuty.FirstOrDefault(v => v.Naim == valName);
            if (valyuta == null)
            {
                Console.WriteLine("Valuutta ei leitud!");
                return;
            }

            double eur = summa / valyuta.KursEurOtnoshenie;
            Console.WriteLine($"{summa} {valyuta.Naim} = {eur:F2} EUR");

            Valyuta usd = valyuty.First(v => v.Naim == "USD");
            double usdSum = eur * usd.KursEurOtnoshenie;
            Console.WriteLine($"{eur:F2} EUR = {usdSum:F2} USD");
        }
    }
}

