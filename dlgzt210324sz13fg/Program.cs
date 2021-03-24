using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlgzt210324sz13fg
{
    class Program
    {
        static int[] tomb = new int[100];

        static void FillTomb()
        {
            var rnd = new Random();
            for (int i = 0; i < tomb.Length; i++)
            {
                int tmp = rnd.Next(999, 9999);
                while (tmp % 5 != 0)
                    tmp = rnd.Next(999, 9999);

                tomb[i] = tmp;
            }
        }

        static void PrintTomb()
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if ((i + 1) % 7 == 0) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{tomb[i]} ");
                Console.ResetColor();
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
        }

        static void TombCalcs()
        {
            Console.WriteLine($"A tömb elemeinek összege: {tomb.Sum()}");
            
            int sum = 0;
            int counter = 0;
            foreach (var szam in tomb)
            {
                if (szam >= 4000 || szam < 5000)
                {
                    sum += szam;
                    counter++;
                }
            }

            Console.WriteLine($"A kért elemek átlaga: {sum/counter}");
        
            int i = 0;
            while (i < tomb.Length && tomb[i] % 65 != 0)
                i++;

            if (i < tomb.Length)
                Console.WriteLine($"A(z) {i} indexű elem: {tomb[i]}; ami osztható 65-tel.");
            else
                Console.WriteLine("Nem szerepel a tömbben 65-nek többszöröse.");


            counter = 0;
            foreach (var szam in tomb)
                if (szam - 3000 < 1000 && szam - 3000 >= 0)
                    counter++;

            Console.WriteLine($"A 3-as számmal kezdődő számok száma: {counter}");
        }

        static void Fizu()
        {
            int i = 0;
            while (i < tomb.Length && tomb[i] < 3000)
                i++;

            if (i < tomb.Length)
                Console.WriteLine($"A(z) elfogadható(?) órabér indexe: {i}.");
            else
                Console.WriteLine("Nem szerepel a tömbben elfogadható junior órabér.");
        }

        static void Valogatott()
        {
            int[] tomb2 = new int[100];
            int j = 0;

            foreach (var szam in tomb)
            {
                if ((szam % 100) == 0)
                {
                    tomb2[j] = szam;
                    j++;
                }
            }

            int i = 0;
            while (i < tomb2.Length && tomb2[i] != 0)
            {
                if (((int)(tomb2[i] / 1000) == (int)((tomb2[i] - (int)(tomb2[i] / 1000) * 1000) * 10) / 1000)) Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{tomb2[i]}");
                Console.ResetColor();
                Console.Write(" ");
                if ((i + 1) % 10 == 0) Console.WriteLine();
                i++;
            }
            Console.WriteLine();
        }

        static void Szuletes()
        {
            int szul = 1994;
            int szulk;

            int mod = szul % 10;
            switch (mod)
            {
                case 1:
                case 2:
                    szulk = szul - mod;
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    szulk = szul + (5 - mod);
                    break;
                case 8:
                case 9:
                    szulk = szul + (10 - mod);
                    break;
                default:
                    szulk = szul;
                    break;
            }

            Console.WriteLine($"A kerekített évszám: {szulk}.");
            
            int i = 0;
            while (i < tomb.Length && tomb[i] != szulk)
                i++;

            if (i < tomb.Length)
                Console.WriteLine("A kerekített évszám szerepel a tömbben.");
            else
                Console.WriteLine("A kerekített évszám nem szerepel a tömbben.");
        }

        static void Main(string[] args)
        {
            FillTomb();
            PrintTomb();
            TombCalcs();
            Fizu();
            Valogatott();
            Szuletes();
            Console.ReadKey();
        }
    }
}
