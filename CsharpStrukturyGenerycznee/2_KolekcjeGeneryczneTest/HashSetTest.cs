using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace _2_KolekcjeGeneryczneTest
{
    [TestClass]
    public class HashSetTest
    {
        [TestMethod]
        public void IntersectSets() //wyodrębnia elementy wspólne z dwóch setów
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            var set2 = new HashSet<int> { 2, 3, 4 };
            set1.IntersectWith(set2);

            Assert.IsTrue(set1.SetEquals(new[] { 2, 3 }));
        }
        [TestMethod]
        public void UnionSets() //łączy zawartości dwóch setów
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            var set2 = new HashSet<int> { 2, 3, 4 };
            set1.UnionWith(set2);

            Assert.IsTrue(set1.SetEquals(new[] { 1, 2, 3, 4 }));
        }
        [TestMethod]
        public void SymmetricExceptSets() //wyodrębnia elementy, które NIE SĄ wspólne
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            var set2 = new HashSet<int> { 2, 3, 4 };
            set1.SymmetricExceptWith(set2);

            Assert.IsTrue(set1.SetEquals(new[] { 1, 4 }));
        }
        [TestMethod]
        public void RemoveSets() //usuwanie czegoś z setu
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            set1.Remove(2); //usunięcie liczby 2 z set1

            Assert.AreEqual(2, set1.Count);
            //Assert.IsFalse(set1.Contains(2)); //fałszem jest, że set1 zawiera liczbę 2
        }
        [TestMethod]
        public void RemoveWhereSets() //usuwanie czegoś z setu, gdzie... (podajemy warunek)
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            set1.RemoveWhere(x => x > 1); //używając RemoveWhere, w nawiasie podajemy warunek, co ma zostać usunięte

            Assert.AreEqual(1, set1.Count);
        }
        [TestMethod]
        public void ContainsSets() //sprawdza, czy set zawiera podany element
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            Assert.IsTrue(set1.Contains(3));
        }
    }
}
