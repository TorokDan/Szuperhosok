using System;

namespace Szuperhosok
{
    class Program
    {
        static void Main(string[] args)
        {
            HosLista hosok = new HosLista();
            
            Szuperhos patrik = new Szuperhos("Patrik", true, 35, 35, Oldalak.Civil);
            // for (int i = 0; i < 5; i++)
            // {
            //     try
            //     {
            //         hosok.Beszuras(patrik);
            //     }
            //     catch (VanMarIlyenHosException e)
            //     {
            //         Console.WriteLine("Ő már szerepel a listában");
            //     }
            // }
            hosok.Beszuras(new Szuperhos("Dani", true, 10, 10, Oldalak.Civil));
            hosok.Beszuras(new Szuperhos("András", false, 20, 20, Oldalak.Gonosz));
            hosok.Beszuras(new Szuperhos("Levi", true, 30, 30, Oldalak.Jo));
            hosok.Beszuras(new Szuperhos("Géza", true, 15, 15, Oldalak.Gonosz));
            hosok.Beszuras(new Szuperhos("Cecil", true, 20, 20, Oldalak.Jo));
            hosok.Beszuras(new Szuperhos("Cecil", true, 20, 20, Oldalak.Jo));
            hosok.Beszuras(patrik);
            hosok.Bejaras(Bejaro);
            Console.WriteLine();
            // try
            // {
            //     hosok.Torles("Joel");
            // }
            // catch (NincsIlyenHosException e)
            // {
            //     Console.WriteLine("Ilyen elem nincs");
            // }
            // hosok.Bejaras(Bejaro);
            // try
            // {
            //     Console.WriteLine(hosok.Keres("Danidfg"));
            // }
            // catch (NincsIlyenHosException e)
            // {
            //     Console.WriteLine(e.Message);
            // }

            // var teszt1 = hosok.LassabbbMint(30);
            // var teszt2 = hosok.ErosebbbMint(10);
            // var teszt3 = teszt1.Metszet(teszt2);
            // var teszt4 = teszt1.Unio(teszt2);
            // var teszt5 = teszt1.Kulonbség(teszt2);
            // Console.WriteLine("teszt1");
            // teszt1.Bejaras(Bejaro);
            // Console.WriteLine("tesz2");
            // teszt2.Bejaras(Bejaro);
            // Console.WriteLine("metszet");
            // teszt3.Bejaras(Bejaro);
            // Console.WriteLine("unio");
            // teszt4.Bejaras(Bejaro);
            // Console.WriteLine("kulonbség");
            // teszt5.Bejaras(Bejaro);

        }

        static void Bejaro(Szuperhos hos)
        {
            Console.WriteLine(hos);
        }
    }
}