using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katselabor.Generaatorid
{
    public interface IArvudeGeneraator
    {
        double[] looArvud(int kogus, params double[] parameetrid);
    }
}
