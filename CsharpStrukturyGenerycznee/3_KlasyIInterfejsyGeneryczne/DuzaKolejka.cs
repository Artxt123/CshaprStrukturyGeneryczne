using System.Collections;
using System.Collections.Generic;

namespace _3_KlasyIInterfejsyGeneryczne
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