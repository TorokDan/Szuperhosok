using System;

namespace Szuperhosok
{
    public class VanMarIlyenHosException : Exception
    {
        public VanMarIlyenHosException() 
            : base("Már létezik ilyen hős a listában!")
        {
            
        }
    }
}