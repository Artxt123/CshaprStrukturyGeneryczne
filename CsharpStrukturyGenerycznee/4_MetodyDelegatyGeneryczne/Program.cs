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

            var kolejka = new KolejkaKolowa<double>();
            WprowadzanieDanych(kolejka);

            //nasz konwerter zamienia double na datę; tworzymy nową datę, której punktem początkowym jest 1.1.2021 i dodajemy do niej liczbę dni
            //Converter<double, DateTime> konwerter = d => new DateTime(2021, 1, 1).AddDays(d);
            //var jakoData = kolejka.Mapuj(konwerter);

            //wyrażenie lambda można od razu wsatwić w metodę Mapuj(), bez tworzenia delegata Converter, kompilator się domyśli sam, że o to chodzi
            var jakoData = kolejka.Mapuj(d => new DateTime(2021, 1, 1).AddDays(d));

            foreach (var item in jakoData)
            {
                Console.WriteLine(item);
            }

            kolejka.Drukuj(d => Console.WriteLine(d));
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
