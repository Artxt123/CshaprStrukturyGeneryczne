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
            //Kolejka();
            //Stos();

            HashSet();



            //Tablica pracowników
            //Pracownik[] pracownicy = new Pracownik[]
            //{
            //    new Pracownik {Imie = "Michał", Nazwisko= "Kowalski"},
            //    new Pracownik {Imie = "Jacek", Nazwisko= "Nowak"},
            //    new Pracownik {Imie = "Alicja", Nazwisko= "Piła"}
            //};

            //foreach (var pracownik in pracownicy)
            //{
            //    Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}");
            //}

            //for (int i = 0; i < pracownicy.Length; i++)
            //{
            //    Console.WriteLine($"{pracownicy[i].Imie} {pracownicy[i].Nazwisko}");
            //}

            //Array.Resize(ref pracownicy, 10);
            //pracownicy[9] = new Pracownik { Imie = "Janusz", Nazwisko = "Kopeć" };

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
