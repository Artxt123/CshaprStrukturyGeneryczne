using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _2_KolekcjeGeneryczneTest
{
    [TestClass]
    public class KolejkaTest
    {
        [TestMethod]
        public void UzyciePeek()
        {
            var kolejka = new Queue<int>();
            kolejka.Enqueue(1);
            kolejka.Enqueue(2);
            kolejka.Enqueue(3);
            kolejka.Enqueue(4);

            Assert.AreEqual(1, kolejka.Peek()); //podgląda następny element w kolejce, ale go nie usuwa z kolejki
            Assert.AreEqual(1, kolejka.Peek());
        }
        [TestMethod]
        public void UzycieContains()
        {
            var kolejka = new Queue<int>();
            kolejka.Enqueue(1);
            kolejka.Enqueue(2);
            kolejka.Enqueue(3);
            kolejka.Enqueue(4);

            Assert.IsTrue(kolejka.Contains(3));
        }
        [TestMethod]
        public void UzycieToArray()
        {
            var kolejka = new Queue<int>();
            kolejka.Enqueue(1);
            kolejka.Enqueue(2);
            kolejka.Enqueue(3);
            kolejka.Enqueue(4);

            var tablica = kolejka.ToArray(); //skopiowianie kolejki do tablicy
            kolejka.Dequeue();

            Assert.AreEqual(1, tablica[0]);
            Assert.AreEqual(3, kolejka.Count);
        }
        [TestMethod]
        public void UzycieClear()
        {
            var kolejka = new Queue<int>();
            kolejka.Enqueue(1);
            kolejka.Enqueue(2);
            kolejka.Enqueue(3);
            kolejka.Enqueue(4);
            kolejka.Clear(); //wyczyszczenie kolejki

            Assert.AreEqual(0, kolejka.Count);
        }
    }
}
