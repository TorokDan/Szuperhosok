using System;

namespace Szuperhosok
{
    public delegate void BejaroHandler(Szuperhos hos);
    public class HosLista // Lehet, hogy ennek genericnek kell lennie
    {
        private HosElem _fej;

        /// <summary>
        /// Új hőst vesz fel. Az erő alapján rendezi az elemeket. Egy elemet csak egyszer lehet felvenni.
        /// </summary>
        /// <param name="ujHos"></param>
        public void Beszuras(Szuperhos ujHos)
        {
            // Bejárás
            HosElem e = null;
            HosElem p = _fej;
            while (p != null && (p.AktualisHos != ujHos || !p.AktualisHos.Equals(ujHos)) && 
                   p.AktualisHos.Ero < ujHos.Ero)
            {
                e = p;
                p = p.KovetkezoHos;
            }
            // Vizsgálat
            if (p != null)
            {
                if ( p.AktualisHos == ujHos || p.AktualisHos.Equals(ujHos)) // van már ilyen hős
                {
                    throw new VanMarIlyenHosException();
                }
                else // Jó helyen vagyunk, ide kell beilleszteni
                {
                    HosElem elem = new HosElem(ujHos);
                    if (e != null)
                        e.KovetkezoHos = elem;
                    else
                        _fej = elem;
                    elem.KovetkezoHos = p;
                }
            }
            else // elem felvétele
            {
                HosElem elem = new HosElem(ujHos);
                if (e != null)
                    e.KovetkezoHos = elem;
                else // első elem
                {
                    elem.KovetkezoHos = _fej;
                    _fej = elem;
                }
            }
        }
        /// <summary>
        /// Név alapján megkeres egy hőst, ha nincs ilyen hős akkor kivételt dob
        /// </summary>
        /// <param name="nev"></param>
        /// <returns></returns>
        public Szuperhos Keres(string nev)
        {
            HosElem p = _fej;
            while (p != null && p.AktualisHos.Name != nev)
            {
                p = p.KovetkezoHos;
            }

            if (p == null)
                throw new NincsIlyenHosException();
            return p.AktualisHos;
        }
        
        /// <summary>
        /// Bejárja a listát, és végrehajtja az elemeken a megadott metódust
        /// </summary>
        /// <param name="metodus"></param>
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
        
        /// <summary>
        /// Név alapján megkeresi a listából az elemet, és törli azt
        /// </summary>
        /// <param name="torlendo"></param>
        /// <exception cref="NincsIlyenElemException"></exception>
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
                if (e == null) // Törlés mert megvan
                    _fej = p.KovetkezoHos; // első elem törlése
                else
                    e.KovetkezoHos = p.KovetkezoHos; // valahanyadik elemet kell törölni
            }
            else // kivétel, mert nincs ilyen elem a listában
                throw new NincsIlyenHosException();
        }
        /// <summary>
        /// Referencia alapján megkeres egy elemet, majd törli azt.
        /// </summary>
        /// <param name="torlendo"></param>
        public void Torles(Szuperhos torlendo) // TODO ide még egy vizsgálat kéne szerintem, de nem értem pontosan a feladatot :(
        {
            HosElem e = null;
            HosElem p = _fej;

            while (p != null && p.AktualisHos != torlendo)
            {
                e = p;
                p = p.KovetkezoHos;
            }
            if (p != null)
            {
                if (e == null) // Törlés mert megvan
                    _fej = p.KovetkezoHos; // első elem törlése
                else
                    e.KovetkezoHos = p.KovetkezoHos; // valahanyadik elemet kell törölni
            }
            else // kivétel, mert nincs ilyen elem a listában
                throw new NincsIlyenHosException();
        }

        /// <summary>
        /// Kigyűjti egy új listába a paraméterként átadott értéknél gyengébb hősöket.
        /// </summary>
        public HosLista GyengebbMint(int hatar)
        {
            HosLista gyengek = new HosLista();
            HosElem p = _fej;

            while (p != null)
            {
                if (p.AktualisHos.Ero < hatar)
                    gyengek.Beszuras(p.AktualisHos);
                p = p.KovetkezoHos;
            }
            return gyengek;
        }
        /// <summary>
        /// Kigyűjti egy új listába a paraméterként átadott értéknél erősebb hősöket.
        /// </summary>
        public HosLista ErosebbbMint(int hatar)
        {
            HosLista erosek = new HosLista();
            HosElem e = null;
            HosElem p = _fej;

            while (p != null)
            {
                if (hatar < p.AktualisHos.Ero)
                    erosek.Beszuras(p.AktualisHos);
                e = p;
                p = p.KovetkezoHos;
            }
            return erosek;
        }
        /// <summary>
        /// Kigyűjti egy új listába a paraméterként átadott értéknél lassabb hősöket.
        /// </summary>
        public HosLista LassabbbMint(int hatar)
        {
            HosLista lassuak = new HosLista();
            HosElem p = _fej;

            while (p != null)
            {
                if (p.AktualisHos.Gyorsasag < hatar)
                    lassuak.Beszuras(p.AktualisHos);
                p = p.KovetkezoHos;
            }
            return lassuak;
        }
        /// <summary>
        /// Kigyűjti egy új listába a paraméterként átadott értéknél gyorsabb hősöket.
        /// </summary>
        public HosLista GyorsabbMint(int hatar)
        {
            HosLista gyorsak = new HosLista();
            HosElem p = _fej;

            while (p != null)
            {
                if (hatar < p.AktualisHos.Gyorsasag)
                    gyorsak.Beszuras(p.AktualisHos);
                p = p.KovetkezoHos;
            }
            return gyorsak;
        }
        /// <summary>
        /// Kigyűjti egy új listába a paraméterként átadott oldalon álló hősöket.
        /// </summary>
        public HosLista AzonosOldaluak(Oldalak oldal)
        {
            HosLista azonosOldaluak = new HosLista();
            HosElem p = _fej;

            while (p != null)
            {
                if (p.AktualisHos.Oldal == oldal)
                    azonosOldaluak.Beszuras(p.AktualisHos);
                p = p.KovetkezoHos;
            }
            return azonosOldaluak;
        }

        /// <summary>
        /// Megkeresi a paraméterül átadott listával a közös elemeket.
        /// </summary>
        /// <param name="vizsgalt"></param>
        /// <returns>Mindkét listában szereplő elemek listája.</returns>
        public HosLista Metszet(HosLista vizsgalt)
        {
            HosLista metszet = new HosLista();
            HosElem p = _fej;

            while (p != null)
            {
                bool van = true;
                try
                {
                    vizsgalt.Keres(p.AktualisHos.Name);
                }
                catch (NincsIlyenHosException exception)
                {
                    van = false;
                }
                if (van)
                    metszet.Beszuras(p.AktualisHos);
                p = p.KovetkezoHos;
            }
            return metszet;
        }

        /// <summary>
        /// Kigyűjti az összes elemet egy listába
        /// </summary>
        /// <param name="vizsgalt"></param>
        /// <returns>Minden elem a két listából egy listába rendezve</returns>
        public HosLista Unio(HosLista vizsgalt)
        {
            HosLista unio = new HosLista();
            HosElem p = _fej;
            while (p != null)
            {
                try
                {
                    unio.Beszuras(p.AktualisHos);
                }
                catch (VanMarIlyenHosException e)
                {
                    
                }
                p = p.KovetkezoHos;
            }

            p = vizsgalt._fej;
            while (p != null)
            {
                try
                {
                    unio.Keres(p.AktualisHos.Name);
                }
                catch (NincsIlyenHosException e)
                {
                    unio.Beszuras(p.AktualisHos);
                }

                p = p.KovetkezoHos;
            }
            
            return unio;
        }

        /// <summary>
        /// Kigyűjti azokat az elemeket, amik nincsenek benne a második listában.
        /// </summary>
        /// <param name="vizsgalt"></param>
        /// <returns></returns>
        public HosLista Kulonbség(HosLista vizsgalt)
        {
            HosLista kulonbseg = new HosLista();
            HosElem p = _fej;

            while (p != null)
            {
                try
                {
                    vizsgalt.Keres(p.AktualisHos.Name);
                }
                catch (NincsIlyenHosException e)
                {
                    kulonbseg.Beszuras(p.AktualisHos);
                }
                p = p.KovetkezoHos;
            }
            return kulonbseg;
        }
    }
}