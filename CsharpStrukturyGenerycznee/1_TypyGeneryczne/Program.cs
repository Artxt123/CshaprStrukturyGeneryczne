using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_TypyGeneryczne
{
    class Program
    {
        static void Main(string[] args)
        {
            var kolejka = new KolejkaKolowa<double>(pojemnosc: 3);
            //var kolejkaInt = new KolejkaKolowa<int>();
            //var kolejkaString = new KolejkaKolowa<string>(pojemnosc: 1000);
            //var kolejkaOsob = new KolejkaKolowa<Osoba>();

            //kolejkaOsob.Zapisz(new Osoba() { Imie = "Michał", Nazwisko = "Kowalski" });
            //kolejkaOsob.Zapisz(new Osoba() { Imie = "Karol", Nazwisko = "Raczak" });
            //kolejkaOsob.Zapisz(new Osoba() { Imie = "Daniel", Nazwisko = "Nowak" });
            //kolejkaOsob.Zapisz(new Osoba() { Imie = "Alicja", Nazwisko = "Glinka" });

            //while (!kolejkaOsob.JestPusty)
            //{
            //    var osoba = kolejkaOsob.Czytaj();
            //    Console.WriteLine($"{osoba.Imie} {osoba.Nazwisko}");
            //}

            WprowadzanieDanych(kolejka);
            PrzetwarzanieDanych(kolejka);

            //Console.WriteLine($"Pojemność: {kolejka.Pojemnosc}");

            // Odczytywanie po kolei tego co jest w kolejce
            //while (!kolejka.JestPusty)
            //{
            //    Console.WriteLine($"\t\t {kolejka.Czytaj()}");
            //}

            //Sumowanie, gdy kolejka typu object i aby nie sumować stringów
            //while (!kolejka.JestPusty)
            //{
            //    var wartosc = kolejka.Czytaj();
            //    if (wartosc is double)
            //    {
            //        suma += (double)wartosc;
            //    }
            //}
        }

        private static void PrzetwarzanieDanych(KolejkaKolowa<double> kolejka)
        {
            var suma = 0.0;
            Console.WriteLine("Suma wartości w naszej kolejce wynosi:");

            while (!kolejka.JestPusty)
            {
                suma += kolejka.Czytaj();
            }
            Console.WriteLine(suma);
        }

        private static void WprowadzanieDanych(KolejkaKolowa<double> kolejka)
        {
            while (true)
            {
                var wartoscWejsciowa = Console.ReadLine();

                if (double.TryParse(wartoscWejsciowa, out double wartosc))
                {
                    kolejka.Zapisz(wartosc);
                    continue;
                }
                break;
            }
        }
    }

    //public class Osoba
    //{
    //    public string Imie { get; set; }
    //    public string Nazwisko { get; set; }
    //}
}
