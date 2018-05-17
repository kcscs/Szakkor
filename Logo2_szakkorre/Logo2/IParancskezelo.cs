using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo2
{
    interface IParancskezelo
    {
        void Parancs(string str);
        void Init();
        Pont teknosHely();

        /// <summary>
        /// felfele 0, az óramutató járásának megfelelően
        /// </summary>
        /// <returns></returns>
        float teknosIrany();
    }
}
