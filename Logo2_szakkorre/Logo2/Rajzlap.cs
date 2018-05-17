using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo2
{
    public class Rajzlap {
        static Rajzlap instance;
        static Form1 form;

        public Rajzlap(Form1 _form) {
            instance = this;
            form = _form;
        }

        public static void RajzolVonal(Pont innen, Pont ide, Szin szin, float vastagsag = 1f) {
            form.DrawLine(innen, ide, szin, vastagsag);
        }

        public static void RajzolKor(Pont kozeppont, float sugar, Szin szin, float vastagsag = 1f) {
            form.DrawCircle(kozeppont, sugar, szin, vastagsag);
        }

        public static void Torol() => form.Clear();

        public static int Szelesseg { get { return form.rajz.Width; } }
        public static int Magassag { get { return form.rajz.Height; } }

        public static void MentesPNG(string fajl) {
            form.ExportPNG(fajl);
        }
    }
}
