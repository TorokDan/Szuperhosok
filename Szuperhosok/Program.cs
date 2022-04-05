using System;

namespace Szuperhosok
{
    class Program
    {
        static void Main(string[] args)
        {
            HosLista<Szuperhos> hosok = new HosLista<Szuperhos>();

            Szuperhos patrik = new Szuperhos("Patrik", true, 35, 35, Oldalak.Civil);
            hosok.UjElem(patrik);
            try
            {
                hosok.UjElem(patrik);
            }
            catch (VanMarIlyenHosException e)
            {
                Console.WriteLine("Ő már szerepel a listában");
                throw;
            }
            
            hosok.UjElem(new Szuperhos("Dani", true, 10, 10, Oldalak.Civil));
            hosok.UjElem(new Szuperhos("András", false, 20, 20, Oldalak.Gonosz));
            hosok.UjElem(new Szuperhos("Levi", true, 30, 30, Oldalak.Jo));
            hosok.UjElem(new Szuperhos("Patrik", true, 35, 35, Oldalak.Civil));
            hosok.UjElem(new Szuperhos("Géza", true, 15, 15, Oldalak.Gonosz));
            hosok.UjElem(new Szuperhos("Cecil", true, 20, 20, Oldalak.Jo));
            hosok.Bejaras(Bejaro);
            // try
            // {
            //     hosok.Torles("Joel");
            // }
            // catch (NincsIlyenElemException e)
            // {
            //     Console.WriteLine("Ilyen elem nincs");
            // }
            // hosok.Bejaras(Bejaro);
        }

        static void Bejaro(Szuperhos hos)
        {
            Console.WriteLine(hos.ToString());
        }
    }
}