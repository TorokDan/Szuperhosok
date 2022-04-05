namespace Szuperhosok
{
    public delegate void BejaroHandler(Szuperhos hos);
    public class HosLista<T>
    {
        private HosElem _fej;


        public void UjElem(Szuperhos ujHos)
        {
            HosElem elem = new HosElem();
            elem.AktualisHos = ujHos;
            elem.KovetkezoHos = _fej;
            _fej = elem;
        }

        public void Bejaras(BejaroHandler metodus)
        {
            BejaroHandler _metodus = metodus;
            HosElem elem = _fej;
            while (elem != null)
            {
                metodus?.Invoke(elem.AktualisHos);
                elem = elem.KovetkezoHos;
            }
        }
    }
}