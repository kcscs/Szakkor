using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Logo2
{
    public class Pont{
        public int X, Y;

        public Pont() { }
        public Pont(int x, int y) {
            X = x;
            Y = y;
        }
        public Point GetPoint()
        {
            return new Point(X, Rajzlap.Magassag - Y);
        }

        public static Pont operator+(Pont a, Pont b) {
            return new Pont(a.X + b.X, a.Y + b.Y);
        }

        public static Pont operator-(Pont a, Pont b) {
            return new Pont(a.X - b.X, a.Y - b.Y);
        }

        public static Pont operator*(Pont a, float l) {
            return new Pont((int)(a.X * l), (int)(a.Y * l));
        }
    }

    public class Szin
    {
        public byte R, G, B;
        public Szin() { }
        public Szin(byte _R, byte _G, byte _B)
        {
            R = _R;
            G = _G;
            B = _B;
        }
        public Color GetColor()
        {
            return Color.FromArgb(R, G, B);
        }
    }


    public class Vonal
    {
        public Pont p1;
        public Pont p2;
        public Szin szin;
        public float vastagsag = 1;
        public Vonal() { }
        public Vonal(Pont _p1, Pont _p2, Szin _szin,float _vastagsag = 1) {
            p1 = _p1;
            p2 = _p2;
            szin = _szin;
            vastagsag = _vastagsag;
        }

    }

    public class Kor
    {
        public Pont kozeppont;
        public float sugar;
        public Szin szin;
        public float vastagsag = 1f;

        public Kor() { }
        public Kor(Pont _kozeppont, float _sugar, Szin _szin, float _vastagsag = 1f) {
            kozeppont = _kozeppont;
            sugar = _sugar;
            szin = _szin;
            vastagsag = _vastagsag;
        }
    }

}
