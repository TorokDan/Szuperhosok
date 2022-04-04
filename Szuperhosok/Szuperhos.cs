namespace Szuperhosok
{
    public enum Oldalak {Jo, Gonosz, Civil}
    public class Szuperhos
    {
        private string _name;
        private bool _mutant;
        private int _ero;
        private int _gyorsasag;
        private Oldalak _oldal;

        public string Name => _name;
        public int Ero => _ero;
        
        public Szuperhos(string name, bool mutant, int ero, int gyorsasag, Oldalak oldal)
        {
            _name = name;
            _mutant = mutant;
            _ero = ero;
            _gyorsasag = gyorsasag;
            _oldal = oldal;
        }
    }
}