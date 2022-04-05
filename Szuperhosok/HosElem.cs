namespace Szuperhosok
{
    public class HosElem
    {
        private Szuperhos _aktualisHos;
        private HosElem _kovetkezoHos;

        public Szuperhos AktualisHos
        {
            get => _aktualisHos;
            set => _aktualisHos = value;
        }
        public HosElem KovetkezoHos
        {
            get => _kovetkezoHos;
            set => _kovetkezoHos = value;
        }
    }
}