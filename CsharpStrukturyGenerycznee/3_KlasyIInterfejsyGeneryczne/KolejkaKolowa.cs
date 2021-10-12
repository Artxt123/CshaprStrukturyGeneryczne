using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_KlasyIInterfejsyGeneryczne
{
    public class KolejkaKolowa<T> : IKolejka<T>
    {
        private T[] bufor;
        private int poczatekBufora;
        private int koniecBufora;

        public KolejkaKolowa() : this(pojemnosc: 5)
        {

        }
        public KolejkaKolowa(int pojemnosc)
        {
            bufor = new T[pojemnosc + 1];
            poczatekBufora = 0;
            koniecBufora = 0;
        }

        public void Zapisz(T wartosc)
        {
            bufor[koniecBufora] = wartosc;
            koniecBufora = (koniecBufora + 1) % bufor.Length;

            if (koniecBufora == poczatekBufora)
                poczatekBufora = (poczatekBufora + 1) % bufor.Length;
        }

        public T Czytaj()
        {
            var wynik = bufor[poczatekBufora];
            poczatekBufora = (poczatekBufora + 1) % bufor.Length;
            return wynik;
        }

        public int Pojemnosc
        {
            get { return bufor.Length; }
        }

        public bool JestPusty
        {
            get
            {
                return koniecBufora == poczatekBufora;
            }
        }

        public bool JestPelny
        {
            get
            {
                return (koniecBufora + 1) % bufor.Length == poczatekBufora;
            }
        }
    }

}
