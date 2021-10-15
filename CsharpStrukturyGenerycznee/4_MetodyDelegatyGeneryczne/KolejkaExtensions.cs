using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;

namespace _4_MetodyDelegatyGeneryczne
{
    public static class KolejkaExtensions
    {
        /// <summary>
        /// Metoda rozszerzenia, która jest dostępna dla każdego typu IKolejkaT
        /// Metoda potrzebna, aby zwracać elementy w kolejce jako już inny typ danych:
        ///np. mamy w kolejce double, a chcemy, aby komuś wypisywało od razu inty
        /// </summary>
        /// <typeparam name="Twyjscie"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Twyjscie> Mapuj<T, Twyjscie>(this IKolejka<T> kolejka, Converter<T, Twyjscie> konwerter) // to pierwsze w nawiasie wskazuje, że jest to metoda rozszerzająca dla kolejki typu IKolejkaT
        {
            //po uproszczeniu z wykorzystainem Select i wyrażenia lambda
                //Select() wymaga jako parametru delegata Func, który coś przyjmuje i coś zwraca
                //Aby go zaspokoić podajemy wyrażenie lambda, Select przyjumuje T i zwraca przekonwertowaną wartość
                //Dla każdego elementu "i" wykonujemy konwersję
            return kolejka.Select(i => konwerter(i));


            //przed uproszczeniem:
                //przechodzimy przez elementy w kolejce i konwertujemy je na typ wyjściowy
                //foreach (var item in kolejka)
                //{
                //    Twyjscie wynik = konwerter(item);
                //    //zwracamy leniwie typ wyjściowy, ktory przed chwilą otrzymaliśmy
                //    yield return wynik;
                //}

            
        }

        public static void Drukuj<T>(this IKolejka<T> kolejka, Action<T> wydruk)
        {
            foreach (var item in kolejka)
            {
                wydruk(item);
            }
        }
    }
}
