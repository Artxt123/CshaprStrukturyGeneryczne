using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _2_KolekcjeGeneryczneTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void DodawaniePoElemencie()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Artur");
            lista.AddLast("Jakub");
            lista.AddAfter(lista.First, "Marysia");

            Assert.AreEqual("Marysia", lista.First.Next.Value);
        }
        [TestMethod]
        public void DodawaniePrzedElementem()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Artur");
            lista.AddLast("Jakub");
            lista.AddBefore(lista.First, "Daria");

            Assert.AreEqual("Daria", lista.First.Value);
        }
        [TestMethod]
        public void UsuwanieOstatniegoElementu()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Artur");
            lista.AddLast("Jakub");
            lista.RemoveLast();

            Assert.AreEqual(lista.First, lista.Last); //został jeden element, który jest zarazem pierwszy i ostatni
        }
        [TestMethod]
        public void UsuwanieElementu()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Artur");
            lista.AddLast("Jakub");
            lista.Remove("Artur");

            Assert.AreEqual("Jakub", lista.Last.Value);
        }
        [TestMethod]
        public void CzyListaZawieraElement()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Artur");
            lista.AddLast("Jakub");

            Assert.IsTrue(lista.Contains("Artur"));
        }
        [TestMethod]
        public void CzyszczenieListy()
        {
            var lista = new LinkedList<string>();
            lista.AddFirst("Artur");
            lista.AddLast("Jakub");
            lista.Clear();

            Assert.AreEqual(0, lista.Count);
        }
    }
}
