namespace _3_KlasyIInterfejsyGeneryczne
{
    internal class DuzaKolejka<T> : IKolejka<T>
    {
        private int pojemnosc;

        public DuzaKolejka()
        {
           
        }

        public bool JestPelny => throw new System.NotImplementedException();

        public bool JestPusty => throw new System.NotImplementedException();

        public T Czytaj()
        {
            throw new System.NotImplementedException();
        }

        public void Zapisz(T wartosc)
        {
            throw new System.NotImplementedException();
        }
    }
}