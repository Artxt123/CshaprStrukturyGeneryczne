using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_KolekcjeGeneryczneTest
{
    [TestClass]
    public class ListaTest
    {
        [TestMethod]
        public void ListaMożemyDodawacNaKoniec()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3, };
            listaLiczb.Add(4);

            Assert.AreEqual(4, listaLiczb[3]);
        }
        [TestMethod]
        public void ListaMożemyDodawacNaPozycji()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3, };
            listaLiczb.Insert(1, 8);

            Assert.AreEqual(8, listaLiczb[1]);
        }
        [TestMethod]
        public void ListaMożemyUsuwacElement()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3, };
            listaLiczb.Remove(2);

            Assert.IsTrue(listaLiczb.SequenceEqual(new[] { 1, 3 }));
        }
        [TestMethod]
        public void ListaMożemyUsuwacElementNaPozycji()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3, };
            listaLiczb.RemoveAt(0);

            Assert.IsTrue(listaLiczb.SequenceEqual(new[] { 2, 3 }));
        }
        [TestMethod]
        public void ListaMożemyWyszukiwacIndexElementu()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3, };

            Assert.AreEqual(listaLiczb.IndexOf(3), 2);
        }
        [TestMethod]
        public void ListaMożemyWyszukiwacCzyZawiera()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3, };

            Assert.IsTrue(listaLiczb.Contains(2));
        }
        [TestMethod]
        public void ListaMożemyDodawacZakres()
        {
            List<int> listaLiczb = new List<int> { 1, 2, 3, };

            var zakres = new List<int> { 4, 5, 6, 7, };
            listaLiczb.AddRange(zakres);

            Assert.AreEqual(7, listaLiczb[6]);
        }
    }
}
