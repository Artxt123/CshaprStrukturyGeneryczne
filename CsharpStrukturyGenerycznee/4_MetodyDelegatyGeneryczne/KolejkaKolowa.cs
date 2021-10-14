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
                kolejka.Dequeue();
            }
            base.Zapisz(wartosc);
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
    }

}
