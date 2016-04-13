using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katselabor.Generaatorid
{
    public class YhtlaseJaotusegaGeneraator : IArvudeGeneraator
    {
        /// <summary>
        /// Uniform-jaotusega andmed
        /// </summary>
        /// <param name="kogus">Väljastatavate arvude arv</param>
        /// <param name="parameetrid">Kaks reaalarvu - miinimum ja maksimum</param>
        /// <returns></returns>
        Random r = new Random();
        public double[] looArvud(int kogus, params double[] parameetrid)
        {
            if (parameetrid.Length != 2) { throw new Exception("Puuduvad miinimum ja maksimum"); }
            double[] vastus = new double[kogus];
            for (int i = 0; i < kogus; i++) {
                vastus[i] = r.NextDouble() * (parameetrid[1] - parameetrid[0]) + parameetrid[0];
            }
            return vastus;
        }
    }
}
