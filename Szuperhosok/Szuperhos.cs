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
        public int Gyorsasag => _gyorsasag;
        public Oldalak Oldal => _oldal;
        
        public Szuperhos(string name, bool mutant, int ero, int gyorsasag, Oldalak oldal)
        {
            _name = name;
            _mutant = mutant;
            _ero = ero;
            _gyorsasag = gyorsasag;
            _oldal = oldal;
        }

        public override string ToString()
        {
            return $"{_name}, {_mutant}, {_ero}, {_gyorsasag}, {_oldal}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(this.GetType() == obj.GetType()))
                return false;
            else if (this._name == ((Szuperhos)obj)._name && 
                     this._mutant == ((Szuperhos)obj)._mutant &&
                     this._ero == ((Szuperhos)obj)._ero &&
                     this._gyorsasag == ((Szuperhos)obj)._gyorsasag &&
                     this._oldal == ((Szuperhos)obj)._oldal)
            {
                return true;
            }
        
            return false;
        }
    }
}