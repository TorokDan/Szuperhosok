namespace Szuperhosok
{
    delegate void BejaroHandler(Szuperhos hos);
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

        // public Szuperhos Kereses(string nev)
        // {
        //     HosElem<Szuperhos>
        // }
    }
}