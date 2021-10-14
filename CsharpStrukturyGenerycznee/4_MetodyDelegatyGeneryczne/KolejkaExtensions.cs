using System.Collections.Generic;
using System.ComponentModel;
using System;

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
        public static IEnumerable<Twyjscie> ElementJako<T, Twyjscie>(this IKolejka<T> kolejka) // to w nawiasie wskazuje, że jest to metoda rozszerzająca dla kolejki typu IKolejkaT
        {
            //tworzymy konwerter dla naszego typu danych
            var konwerter = TypeDescriptor.GetConverter(typeof(T));

            //przechodzimy przez elementy w kolejce i konwertujemy je na typ wyjściowy
            foreach (var item in kolejka)
            {
                var wynik = konwerter.ConvertTo(item, typeof(Twyjscie));
                //zwracamy leniwie typ wyjściowy, ktory przed chwilą otrzymaliśmy
                yield return (Twyjscie)wynik;
            }
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
