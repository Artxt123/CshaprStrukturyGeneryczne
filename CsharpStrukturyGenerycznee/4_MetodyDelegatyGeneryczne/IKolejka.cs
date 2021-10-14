using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_MetodyDelegatyGeneryczne
{
    public interface IKolejka<T> : IEnumerable<T>
    //POZOSTAŁE INTERFEJSY GENERYCZNE:
    //IList<T>, ICollection<T>, IDictionary<T,T>, IReadOnlyCollection<T>, ISet<T>, IComparer<T>, IEqualityComparer<T>
    {
        bool JestPelny { get; }
        bool JestPusty { get; }

        T Czytaj();
        void Zapisz(T wartosc);

        IEnumerable<Twyjscie> ElementJako<Twyjscie>();
    }

}
