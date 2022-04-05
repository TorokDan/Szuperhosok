using System;

namespace Szuperhosok
{
    public class NincsIlyenHosException : Exception
    {
        public NincsIlyenHosException() 
            : base("Nincs ilyen hős a listában.")
        {
            
        }
    }
}