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

        public void Torles(string torlendo)
        {
            HosElem e = null;
            HosElem p = _fej;

            while (p != null && p.AktualisHos.Name != torlendo)
            {
                e = p;
                p = p.KovetkezoHos;
            }

            if (p != null)
            {
                // Törlés mert megvan
                if (e == null)
                {
                    // első elem törlése
                    _fej = p.KovetkezoHos;
                }
                else
                {
                    // valahanyadik elemet kell törölni
                    e.KovetkezoHos = p.KovetkezoHos;
                    
                }
            }
            else
            {
                // kivétel, mert nincs ilyen elem a listában
                throw new NincsIlyenElemException();
            }
        }
    }
}