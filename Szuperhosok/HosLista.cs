using System;

namespace Szuperhosok
{
    public delegate void BejaroHandler(Szuperhos hos);
    public class HosLista
    {
        private HosElem _fej;

        /// <summary>
        /// Új hőst vesz fel. Az erő alapján rendezi az elemeket. Egy elemet csak egyszer lehet felvenni.
        /// </summary>
        /// <param name="ujHos"></param>
        public void Beszuras(Szuperhos ujHos) // TODO Az új hős tartalmát is kéne vizsgálni szerintem
        {
            // Bejárás
            HosElem e = null;
            HosElem p = _fej;
            while (p != null && p.AktualisHos != ujHos && p.AktualisHos.Ero < ujHos.Ero)
            {
                e = p;
                p = p.KovetkezoHos;
            }
            // Vizsgálat
            if (p != null) //  TODO Ez itt hibás lehet még
            {
                if ( p.AktualisHos == ujHos) // van már ilyen hős
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
            HosElem e = null;
            HosElem p = _fej;
            while (p != null && p.AktualisHos.Name != nev)
            {
                e = p;
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

        public HosLista Szures()
        {
            throw new NotImplementedException();
        }
    }
}