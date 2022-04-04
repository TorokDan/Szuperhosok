namespace Szuperhosok
{
    public class HosElem<T>
    {
        private T _aktualisHos;
        private HosElem<Szuperhos> _kovetkezoHos;

        public T AktualisHos
        {
            get => _aktualisHos;
            set => _aktualisHos = value;
        }
        public HosElem<Szuperhos> KovetkezoHos
        {
            get => _kovetkezoHos;
            set => _kovetkezoHos = value;
        }
    }
}