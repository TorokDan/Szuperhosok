using System;

namespace Szuperhosok
{
    public class NincsIlyenElemException : Exception
    {
        public NincsIlyenElemException() 
            : base("Nincs ilyen elem a láncolt listában!")
        {
            
        }
    }
}