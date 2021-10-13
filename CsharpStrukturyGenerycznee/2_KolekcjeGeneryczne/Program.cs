using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_KolekcjeGeneryczne
{
    class Program
    {
        static void Main(string[] args)
        {
            //TablicaPracowników();
            //Kolejka();
            //Stos();
            //HashSet();
            //LinkedList();
            //LinkedList2();
            //Dictionary0();
            //Dictionary();
            //SortedDictionary();
            //SortedList();
            //SortedSet();

            //Posortowany słownik, aby były posortowane działy i posortowany Set, aby pracownicy byli posortowani po naziwsku
            var pracownicy = new SortedDictionary<string, SortedSet<Pracownik>>();

            //teraz robimy tak, aby nie można było dodać pracowników o tym samym nazwisku
            pracownicy.Add("Sprzedaż", new SortedSet<Pracownik>(new PracownikComparer()));
            pracownicy["Sprzedaż"].Add(new Pracownik { Imie = "Iwan", Nazwisko = "Nowak" });
            pracownicy["Sprzedaż"].Add(new Pracownik { Imie = "Iwona", Nazwisko = "Jelcz" });
            pracownicy["Sprzedaż"].Add(new Pracownik { Imie = "Krzysztof", Nazwisko = "Mercedes" });
            pracownicy["Sprzedaż"].Add(new Pracownik { Imie = "Iwan", Nazwisko = "Nowak" });

            pracownicy.Add("Księgowość", new SortedSet<Pracownik>(new PracownikComparer()));
            pracownicy["Księgowość"].Add(new Pracownik { Imie = "Janusz", Nazwisko = "Nowak" });
            pracownicy["Księgowość"].Add(new Pracownik { Imie = "Wojciech", Nazwisko = "Kowalski" });
            pracownicy["Księgowość"].Add(new Pracownik { Imie = "Anna", Nazwisko = "Roman" });
            pracownicy["Księgowość"].Add(new Pracownik { Imie = "Izabela", Nazwisko = "Ochojska" });
            pracownicy["Księgowość"].Add(new Pracownik { Imie = "Janusz", Nazwisko = "Nowak" });

            foreach (var dzial in pracownicy)
            {
                Console.WriteLine(dzial.Key);
                foreach (var pracownik in dzial.Value)
                {
                    Console.WriteLine($"\t {pracownik.Imie} {pracownik.Nazwisko}");
                }
                Console.WriteLine();
            }

        }

        private static void SortedSet()
        {
            //SortedSet działa tak jak HashSet (czyli uniemożliwia dodania duplikatu), ale dodatkowo sortuje wprowadzone wartości
            var set = new SortedSet<int>();
            set.Add(8);
            set.Add(7);
            set.Add(9);
            set.Add(10);
            set.Add(1);
            set.Add(0);

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            //...
            var set2 = new SortedSet<string>();
            set2.Add("Kasia");
            set2.Add("Basia");
            set2.Add("Jola");
            set2.Add("Ola");
            set2.Add("Wiola");

            set2.Add("Tola");
            foreach (var item in set2)
            {
                Console.WriteLine(item);
            }
        }

        private static void SortedList()
        {
            var listaPosortowana = new SortedList<int, string>();
            listaPosortowana.Add(4, "cztery");
            listaPosortowana.Add(2, "dwa");
            listaPosortowana.Add(5, "pięć");
            listaPosortowana.Add(1, "jeden");

            foreach (var item in listaPosortowana)
            {
                Console.WriteLine(item.Value);
            }
        }

        private static void SortedDictionary()
        {
            //UPDATE: zmiana z SortedDictionary na SortedList, bo SortedList jest bardziej zoptymalizowane pod kątem odczytywania
            //SortedList zapewnia najszybszą iterację po Liście (zużywając przy tym mało pamięci) a tego tutaj używamy

            //SortedDictionary jest lepsze jeżeli chodzi o wprowadzanie wartości do niego i usuwania ich.
            //Gdybyśmy odwoływali się do elementu po kluczu, wtedy lepszym rozwiązeniem byłoby SortedDictionary, zużywa on więcej pamięci, ale jest wydajniejszy w takich przypadkach

            //SortedDictionary (i SortedList) sortuje klucze w kolejności alfabetycznej dla stringów, rosnącej dla liczb; wtedy się przydaje
            var pracownicy = new SortedList<string, List<Pracownik>>();
            pracownicy.Add("Sprzedaż", new List<Pracownik>
            {
                new Pracownik { Imie = "Andrzej", Nazwisko = "Marciniak" },
                new Pracownik {Imie = "Patryk", Nazwisko = "Tomczak"},
                new Pracownik {Imie = "Dominik", Nazwisko = "Gackowski"}
            });
            pracownicy.Add("Informatyka", new List<Pracownik>
            {
                new Pracownik { Imie = "Paweł", Nazwisko = "Matuszewski" },
                new Pracownik {Imie = "Sławomir", Nazwisko = "Kubiak"}
            });
            pracownicy.Add("Księgowość", new List<Pracownik>
            {
                new Pracownik { Imie = "Irena", Nazwisko = "Nawrocka" },
                new Pracownik {Imie = "Tomasz", Nazwisko = "Kozica"},
                new Pracownik {Imie = "Maciej", Nazwisko = "Szymczak"},
                new Pracownik {Imie = "Michał", Nazwisko = "Szymandera"}
            });


            foreach (var dzial in pracownicy)
            {
                Console.WriteLine($"Ilość pracowników w dziale {dzial.Key} wynosi: {dzial.Value.Count}");
            }
        }

        private static void Dictionary0()
        {
            //robimy słownik, którego kluczem jest nazwisko, a zawartością jest lista pracowników o tym samym nazwisku;
            //dzięki temu możemy dodać dwóch pracowników o tym samym nazwisku, używając jako klucza ich identycznego nazwiska
            var pracownicy = new Dictionary<string, List<Pracownik>>();
            pracownicy.Add("Andrzejak", new List<Pracownik>() { new Pracownik { Imie = "Michał", Nazwisko = "Andrzejak" } });
            pracownicy.Add("Miła", new List<Pracownik>() { new Pracownik { Imie = "Katarzyna", Nazwisko = "Miła" } });

            pracownicy["Andrzejak"].Add(new Pracownik { Imie = "Natalia", Nazwisko = "Andrzejak" });

            foreach (var lista in pracownicy)
            {
                foreach (var pracownik in lista.Value)
                {
                    Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}");
                }
            }
        }

        private static void Dictionary()
        {
            //słownik, którego kluczem są działy, wartością listy pracowników z danego działu
            var pracownicy = new Dictionary<string, List<Pracownik>>();
            pracownicy.Add("Księgowość", new List<Pracownik>
            {
              new Pracownik { Imie = "Michał", Nazwisko = "Andrzejak" },
              new Pracownik { Imie = "Izabela", Nazwisko = "Mądrecka" },
              new Pracownik { Imie = "Marcin", Nazwisko = "Poradzisz" }
            });

            pracownicy["Księgowość"].Add(new Pracownik { Imie = "Natalia", Nazwisko = "Andrzejak" });

            pracownicy.Add("Informatyka", new List<Pracownik>
            {
              new Pracownik { Imie = "Marek", Nazwisko = "Rajkiewicz" },
              new Pracownik { Imie = "Wojciech", Nazwisko = "Wiertlewski" }
            });

            //wyświetlenie wszystkich pracowników z wszystkich działów
            foreach (var dzial in pracownicy)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Dział : {dzial.Key}:"); //wypisujemy nazwę działu
                Console.ResetColor();
                foreach (var pracownik in dzial.Value)
                {
                    Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}"); //imię i nazwisko pracownika z danego działu
                }
                Console.WriteLine();
            }

            //wyświetlenie praconików z konkretnego działu
            Console.WriteLine("Pracownicy z działu Księgowość:");
            foreach (var pracownik in pracownicy["Księgowość"])
            {
                Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}");
            }
        }

        private static void TablicaPracowników()
        {
            Pracownik[] pracownicy = new Pracownik[]
            {
                new Pracownik {Imie = "Michał", Nazwisko= "Kowalski"},
                new Pracownik {Imie = "Jacek", Nazwisko= "Nowak"},
                new Pracownik {Imie = "Alicja", Nazwisko= "Piła"}
            };

            foreach (var pracownik in pracownicy)
            {
                Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}");
            }

            for (int i = 0; i < pracownicy.Length; i++)
            {
                Console.WriteLine($"{pracownicy[i].Imie} {pracownicy[i].Nazwisko}");
            }

            Array.Resize(ref pracownicy, 10);
            pracownicy[9] = new Pracownik { Imie = "Janusz", Nazwisko = "Kopeć" };
        }

        private static void LinkedList2()
        {
            LinkedList<int> lista2 = new LinkedList<int>();
            lista2.AddFirst(11);
            lista2.AddFirst(22);
            lista2.AddFirst(33);

            var elementPierwszy = lista2.First;
            var elementOstatni = lista2.Last;

            lista2.AddAfter(elementPierwszy, 333);
            lista2.AddBefore(elementOstatni, 1);

            var wezel = lista2.First;
            while (wezel != null)
            {
                Console.WriteLine(wezel.Value);
                wezel = wezel.Next;
            }
        }

        private static void LinkedList()
        {
            LinkedList<int> lista = new LinkedList<int>();
            lista.AddFirst(11);
            lista.AddFirst(22);
            lista.AddFirst(33);
            lista.AddLast(100);
            lista.AddLast(200);

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }

        private static void HashSet()
        {
            HashSet<Pracownik> set = new HashSet<Pracownik>();
            var pracownik = new Pracownik { Imie = "Michał", Nazwisko = "Andrzejak" };
            set.Add(pracownik);
            set.Add(pracownik);

            foreach (var item in set)
            {
                Console.WriteLine($"{item.Imie} {item.Nazwisko}");
            }
        }

        private static void Kolejka()
        {
            Queue<Pracownik> kolejka = new Queue<Pracownik>();
            kolejka.Enqueue(new Pracownik { Imie = "Michał", Nazwisko = "Andrzejak" });
            kolejka.Enqueue(new Pracownik { Imie = "Katarzyna", Nazwisko = "Miła" });
            kolejka.Enqueue(new Pracownik { Imie = "Marcin", Nazwisko = "Kowalski" });
            kolejka.Enqueue(new Pracownik { Imie = "Tomasz", Nazwisko = "Sęk" });

            Console.WriteLine("Kolejka:");

            while (kolejka.Count > 0)
            {
                var pracownik = kolejka.Dequeue();
                Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}");
            }
        }

        private static void Stos()
        {
            Stack<Pracownik> stos = new Stack<Pracownik>();
            stos.Push(new Pracownik { Imie = "Michał", Nazwisko = "Andrzejak" });
            stos.Push(new Pracownik { Imie = "Katarzyna", Nazwisko = "Miła" });
            stos.Push(new Pracownik { Imie = "Marcin", Nazwisko = "Kowalski" });
            stos.Push(new Pracownik { Imie = "Tomasz", Nazwisko = "Sęk" });

            Console.WriteLine($"\nStos:");
            while (stos.Count > 0)
            {
                var pracownik = stos.Pop();
                Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}");
            }
        }
    }
}
