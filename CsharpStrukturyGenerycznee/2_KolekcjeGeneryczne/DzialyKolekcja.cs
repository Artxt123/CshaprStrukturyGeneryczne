using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_KolekcjeGeneryczne
{
    public class DzialyKolekcja : SortedDictionary<string, SortedSet<Pracownik>>
    {
        public DzialyKolekcja Add(string nazwaDzialu, Pracownik pracownik)
        {
            //jeżeli nie ma jeszcze utworzonego działu, to musimy go utworzyć i zrobić w nim nową listę pracowników:
            if (!ContainsKey(nazwaDzialu))
            {
                Add(nazwaDzialu, new SortedSet<Pracownik>(new PracownikComparer()));
                //ten kod odpowiada temu w głównym programie:
                //pracownicy.Add("Sprzedaż", new SortedSet<Pracownik>(new PracownikComparer()));
            }
            //jak dział już jest utworzony to możemy dodać do niego pracownika
            this[nazwaDzialu].Add(pracownik);
            //ten kod odpowiada temu w głównym programie:
            //pracownicy["Sprzedaż"].Add(new Pracownik { Imie = "Iwan", Nazwisko = "Nowak" });

            //zwracamy DzialyKolekcja, aby w Programie od razu móc po kropce użyć metody Add i dodać od razu nowego pracownika, bez konieczności odwoływania się ponownie do klasy
            return this;

        }
    }
}
