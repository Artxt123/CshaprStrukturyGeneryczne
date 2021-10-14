using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_MetodyDelegatyGeneryczne
{
    class Program
    {
        static void KonsolaWypisz<T>(T dane)
        {
            Console.WriteLine(dane);
        }
        static void Main(string[] args)
        {
            var kolejka = new KolejkaKolowa<double>();

            WprowadzanieDanych(kolejka);

            //var konsolaWyjscie = new Drukarka<double>(KonsolaWypisz); //ta linijka niepotrzebna, można od razu przekazać metodę do kolejka.Drukuj(), bo jest ona zgodna z naszym delegatem, którego metoda Drukuj() oczekuje
            kolejka.Drukuj(KonsolaWypisz); //nie trzeba wpisywać KonsolaWypisz<double>, bo kolejka jest typu double i kompilator sam sobie to dopasuje

            var elementyJakoInt = kolejka.ElementJako<double, int>();
            foreach (var item in elementyJakoInt)
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
