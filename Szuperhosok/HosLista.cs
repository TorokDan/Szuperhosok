namespace Szuperhosok
{
    public class HosLista<T>
    {
        private HosElem<Szuperhos> _fej;


        public void UjElem(Szuperhos ujHos)
        {
            HosElem<Szuperhos> elem = new HosElem<Szuperhos>();
            elem.AktualisHos = ujHos;
            elem.KovetkezoHos = _fej;
            _fej = elem;
        }
    }
}