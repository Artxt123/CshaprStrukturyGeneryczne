﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_KlasyIInterfejsyGeneryczne
{
    class Program
    {
        static void Main(string[] args)
        {
            var kolejka = new KolejkaKolowa<double>();

            WprowadzanieDanych(kolejka);
            foreach (var item in kolejka)
            {
                Console.WriteLine(item);
            }
            PrzetwarzanieDanych(kolejka);
        }

        private static void PrzetwarzanieDanych(IKolejka<double> kolejka)
        {
            var suma = 0.0;
            Console.WriteLine("Suma wartości w naszej kolejce wynosi:");

            while (!kolejka.JestPusty)
            {
                suma += kolejka.Czytaj();
            }
            Console.WriteLine(suma);
        }

        private static void WprowadzanieDanych(IKolejka<double> kolejka)
        {
            while (true)
            {
                var wartoscWejsciowa = Console.ReadLine();

                if (double.TryParse(wartoscWejsciowa, out double wartosc))
                {
                    kolejka.Zapisz(wartosc);
                    continue;
                }
                break;
            }
        }
    }

}
