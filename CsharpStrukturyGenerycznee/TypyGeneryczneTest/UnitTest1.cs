using _1_TypyGeneryczne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _1_TypyGeneryczneTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NowaKolejkaJestPusta()
        {
            var kolejka = new KolejkaKolowa();
            Assert.IsTrue(kolejka.JestPusty);
        }

        [TestMethod]
        public void KolejkaTrzyElementowaJestPelnaPoTrzechZapisach()
        {
            var kolejka = new KolejkaKolowa(pojemnosc: 3);
            kolejka.Zapisz(2.3);
            kolejka.Zapisz(3.6);
            kolejka.Zapisz(7.1);

            Assert.IsTrue(kolejka.JestPelny);
        }

        [TestMethod]
        public void FIFO() //PierwszyWchodziPierwszyWychodzi
        {
            var kolejka = new KolejkaKolowa(pojemnosc: 3);
            var wartosc1 = 2.2;
            var wartosc2 = 3.6;

            kolejka.Zapisz(wartosc1);
            kolejka.Zapisz(wartosc2);

            Assert.AreEqual(wartosc1, kolejka.Czytaj());
            Assert.AreEqual(wartosc2, kolejka.Czytaj());
            Assert.IsTrue(kolejka.JestPusty);
        }
        [TestMethod]
        public void NadpisujeGdyJestWiekszaNizPojemnosc()
        {
            var kolejka = new KolejkaKolowa(pojemnosc: 3);
            var wartosci = new[] { 2.3, 3.4, 4.4, 5.7, 8.8, 9.9 };

            foreach (var wartosc in wartosci)
            {
                kolejka.Zapisz(wartosc);
            }

            Assert.IsTrue(kolejka.JestPelny);
            Assert.AreEqual(wartosci[3], kolejka.Czytaj());
            Assert.AreEqual(wartosci[4], kolejka.Czytaj());
            Assert.AreEqual(wartosci[5], kolejka.Czytaj());
            Assert.IsTrue(kolejka.JestPusty);
        }
    }
}
