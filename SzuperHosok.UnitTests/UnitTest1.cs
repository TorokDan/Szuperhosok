using NUnit.Framework;
using Szuperhosok;
namespace SzuperHosok.UnitTests
{
    [TestFixture]
    public class HosListaTests
    {
        private static readonly Szuperhos dani = new Szuperhos("Dani", true, 10, 10, Oldalak.Civil);
        private static readonly Szuperhos andras = new Szuperhos("András", false, 20, 20, Oldalak.Gonosz);
        private static readonly Szuperhos geza = new Szuperhos("Géza", true, 15, 15, Oldalak.Gonosz);
        private static readonly Szuperhos cecil = new Szuperhos("Cecil", true, 20, 20, Oldalak.Jo);
        private static readonly Szuperhos patrik = new Szuperhos("Patrik", true, 35, 35, Oldalak.Civil);
        
        private HosLista hosok;
        
        [SetUp]
        public void Setup()
        {
            hosok = new HosLista();
            hosok.Beszuras(dani);
            hosok.Beszuras(andras);
            hosok.Beszuras(geza);
            hosok.Beszuras(cecil);
            hosok.Beszuras(patrik);
        }

        [Test]
        public void Keres_Dani_Talal()
        {
            Assert.AreEqual(dani,hosok.Keres("Dani"));
        }
        [Test]
        public void Keres_Patrik_Talal()
        {
            Assert.AreEqual(patrik,hosok.Keres("Patrik"));
        }
        [Test]
        public void Keres_Levi_NincsIlyenHosException()
        {
            Assert.Throws<Szuperhosok.NincsIlyenHosException>(() => hosok.Keres("Levi"));
        }
    }
}