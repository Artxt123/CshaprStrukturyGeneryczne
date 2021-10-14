using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace _4_MetodyDelegatyGeneryczne
{
    public class DuzaKolejka<T> : IKolejka<T>
    {
        protected Queue<T> kolejka;

        public DuzaKolejka()
        {
            kolejka = new Queue<T>();
        }

        public virtual bool JestPelny => throw new System.NotImplementedException();

        public virtual bool JestPusty
        {
            get
            {
                return kolejka.Count == 0;
            }
        }

        public virtual T Czytaj()
        {
            return kolejka.Dequeue();
        }

        public virtual void Zapisz(T wartosc)
        {
            kolejka.Enqueue(wartosc);
        }

        
        /// <summary>
        /// metoda potrzebna, aby zwracać elementy w kolejce jako już inny typ danych:
        ///np. mamy w kolejce double, a chcemy, aby komuś wypisywało od razu inty
        /// </summary>
        /// <typeparam name="Twyjscie"></typeparam>
        /// <returns></returns>
        public IEnumerable<Twyjscie> ElementJako<Twyjscie>()
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

        public IEnumerator<T> GetEnumerator()
        {
            //Aby to działało można zrobić tak:
            //return kolejka.GetEnumerator();

            //Można też zrobić własnego foreach'a w którym będzie jakieś filtrowanie i potem będzie zwracał dane:
            foreach (var item in kolejka)
            {
                //mijesce na jakieś filtoranie danych
                //......

                yield return item; //leniwie zwracamy item, yield pozwala na zwracanie wartości pojedynczo; inaczej nie zadziała
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }
}