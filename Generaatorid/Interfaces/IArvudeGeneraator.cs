using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katselabor.Interfaces
{
    public interface IArvudeGeneraator
    {
        double[] createRandomNumbers(int copys, params double[] maxandmin);
        void saveGenerated(generationHistorySet resultInput);


    }
}
