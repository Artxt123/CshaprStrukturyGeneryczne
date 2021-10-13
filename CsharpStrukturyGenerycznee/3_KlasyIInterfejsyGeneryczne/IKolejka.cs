using System.Collections.Generic;

namespace _3_KlasyIInterfejsyGeneryczne
{
    public interface IKolejka<T> : IEnumerable<T>
        //POZOSTAŁE INTERFEJSY GENERYCZNE:
        //IList<T>, ICollection<T>, IDictionary<T,T>, IReadOnlyCollection<T>, ISet<T>, IComparer<T>, IEqualityComparer<T>
    {
        bool JestPelny { get; }
        bool JestPusty { get; }

        T Czytaj();
        void Zapisz(T wartosc);
    }
}