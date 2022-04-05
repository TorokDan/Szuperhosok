using System;

namespace Szuperhosok
{
    class Program
    {
        static void Main(string[] args)
        {
            HosLista<Szuperhos> hosok = new HosLista<Szuperhos>();
            
            Szuperhos patrik = new Szuperhos("Patrik", true, 35, 35, Oldalak.Civil);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    hosok.Beszuras(patrik);
                }
                catch (VanMarIlyenHosException e)
                {
                    Console.WriteLine("Ő már szerepel a listában");
                }
            }
            hosok.Beszuras(new Szuperhos("Dani", true, 10, 10, Oldalak.Civil));
            hosok.Beszuras(new Szuperhos("András", false, 20, 20, Oldalak.Gonosz));
            hosok.Beszuras(new Szuperhos("Levi", true, 30, 30, Oldalak.Jo));
            hosok.Beszuras(new Szuperhos("Géza", true, 15, 15, Oldalak.Gonosz));
            hosok.Beszuras(new Szuperhos("Cecil", true, 20, 20, Oldalak.Jo));
            hosok.Beszuras(new Szuperhos("Patrik", true, 35, 35, Oldalak.Civil));
            hosok.Bejaras(Bejaro);
            Console.WriteLine();
            try
            {
                hosok.Torles("Joel");
            }
            catch (NincsIlyenElemException e)
            {
                Console.WriteLine("Ilyen elem nincs");
            }
            hosok.Bejaras(Bejaro);
        }

        static void Bejaro(Szuperhos hos)
        {
            Console.WriteLine(hos.Name);
        }
    }
}