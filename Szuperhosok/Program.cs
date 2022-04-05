using System;

namespace Szuperhosok
{
    class Program
    {
        static void Main(string[] args)
        {
            HosLista<Szuperhos> hosok = new HosLista<Szuperhos>();
            
            hosok.UjElem(new Szuperhos("Dani", true, 10, 10, Oldalak.Civil));
            hosok.UjElem(new Szuperhos("András", false, 20, 20, Oldalak.Gonosz));
            hosok.Bejaras(Bejaro);
        }

        static void Bejaro(Szuperhos hos)
        {
            Console.WriteLine(hos.ToString());
        }
    }
}