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
            #region Action

            //Action to delegat, który zawsze zwraca void, może przyjmować od 0 do 16 argumentów
            //Przypisujemy do drukuj metodę anonimową, która przyjumuje double dane i wypisuje je na ekran
            //Action<double> drukuj = delegate (double dane){ Console.WriteLine(dane); };

            //To samo co wyżej tylko przy użyciu wyrażenia lambda:
            //Action<double> drukuj = d => Console.WriteLine(d); //d jest tym double i wypisujemy to na ekranie

            //Inne rzeczy z wykorzystanie Action:
            //Action<double> drukuj = x => Console.WriteLine(x);
            //drukuj(7.89);
            //Action<int, int, int> dodajWypisz = (a, b, c) => Console.WriteLine(a + b + c);
            //dodajWypisz(1, 2, 5);
            #endregion

            Action<bool> drukuj = d => Console.WriteLine(d);
            #region Func
            //Func zawsze zwraca coś zwraca, ten typ określamy na samym końcu przy podawaniu parametrów

            //Tutaj przyjumje double i zwraca double:
            Func<double, double> potegowanie = d => d * d;
            //Tutaj przyjmuje dwa double i zwraca double:
            Func<double, double, double> dodaj = (x, y) => x + y;

            //drukuj(potegowanie(5.5));
            //drukuj(dodaj(3.4, 1.11));
            #endregion


            //Predicate zawsze przyjmuje jeden parametr i zawsze zwraca bool (wartość logiczną)
            Predicate<double> jestMniejszeOdSto = d => d < 100;

            //wywołanie wszystkich powyższych delegatów jednocześnie
            drukuj(jestMniejszeOdSto(potegowanie(dodaj(5, 7))));

            WprowadzanieDanych(kolejka);

            //metoda Drukuj() oczekuje delegata Action, dlatego możemy od razu tutaj wpisać wyrażenie lambda
            kolejka.Drukuj(d => Console.WriteLine(d));

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
