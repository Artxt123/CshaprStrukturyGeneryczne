using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_MetodyDelegatyGeneryczne
{
    public class KolejkaKolowa<T> : DuzaKolejka<T>
    {
        private int pojemnosc;

        public KolejkaKolowa(int pojemnosc = 5)
        {
            this.pojemnosc = pojemnosc;
        }

        public override void Zapisz(T wartosc)
        {
            if (JestPelny)
            {
                var usuniety = kolejka.Dequeue();
                PoUsunieciuElementu(usuniety, wartosc);
            }
            base.Zapisz(wartosc);
        }

        private void PoUsunieciuElementu(T usuniety, T wartosc)
        {
            if (elementUsuniety != null)
            {
                var args = new ElementUsunietyEventArgs<T>(usuniety, wartosc);
                elementUsuniety(this, args);
            }
        }
        #region Zapisz_MetodaZKursu
        //public override void Zapisz(T wartosc)
        //{
        //    base.Zapisz(wartosc);
        //    if (kolejka.Count > pojemnosc)
        //    {
        //        kolejka.Dequeue();
        //    }
        //}
        #endregion
        public override bool JestPelny
        {
            get
            {
                return kolejka.Count == pojemnosc;
            }
        }
        //Zdarzenie - wykorzystanie delegata EventHandler; inaczej musilibyśmy towrzyć delegata i od niego zrobić zdarzenie
        public event EventHandler<ElementUsunietyEventArgs<T>> elementUsuniety;
    }

    public class ElementUsunietyEventArgs<T> : EventArgs
    {
        public T ElementUsuniety { get; set; }
        public T ElementNowy { get; set; }
        public ElementUsunietyEventArgs(T elementUsuniety, T elementNowy)
        {
            ElementUsuniety = elementUsuniety;
            ElementNowy = elementNowy;
        }
    }

}
