using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_MetodyDelegatyGeneryczne
{
    class Program
    {
        static void Main(string[] args)
        {

            var kolejka = new KolejkaKolowa<double>(pojemnosc: 3);
            kolejka.elementUsuniety += Kolejka_elementUsuniety;

            WprowadzanieDanych(kolejka);

            //var jakoData = kolejka.Mapuj(d => new DateTime(2021, 1, 1).AddDays(d));

            //foreach (var item in jakoData)
            //{
            //    Console.WriteLine(item);
            //}

            kolejka.Drukuj(d => Console.WriteLine(d));
            PrzetwarzanieDanych(kolejka);
        }

        private static void Kolejka_elementUsuniety(object sender, ElementUsunietyEventArgs<double> e)
        {
            Console.WriteLine($"Kolejka jest pełna. Element usunięty to: {e.ElementUsuniety}, nowy element to: {e.ElementNowy}.");
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
