
namespace KalkulackaPlus
{
    internal class Kalkulacka
    {
        double _vysledek;

        public Kalkulacka()
        {
            _vysledek = 0;
        }

        internal static bool JePlatnyOperator(string znamenko)
        {
            bool jeToOperator = false;

            switch (znamenko)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                    jeToOperator = true;
                    break;
            }

            return jeToOperator;
        }
        
        internal void Reset()
        {
            _vysledek = 0;
        }

        internal void Odecti(double cislo)
        {
            _vysledek = _vysledek - cislo;
        }

        internal void Pricti(double cislo)
        {
            _vysledek = _vysledek + cislo;
        }

        internal void Umocni(int mocnitel)
        {
            double pomocna = 1;

            for (int i = 0; i < mocnitel; i++)
            {
                pomocna = pomocna * _vysledek;
            }
            _vysledek = pomocna;
            
        }

        internal void Vydel(double cislo)
        {
            _vysledek = _vysledek / cislo;
        }

        internal void Vynasob(double cislo)
        {
            _vysledek = _vysledek * cislo;
        }

        internal double ZiskejVysledek()
        {
            return _vysledek;
        }     
    }
}