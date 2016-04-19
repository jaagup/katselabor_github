using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katselabor.Repos
{
    public class YhtlaseJaotusegaGeneraator : IArvudeGeneraator
    {
        // Initialize logging stuff
        private static Logger logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Uniform-jaotusega andmed
        /// </summary>
        /// <param name="kogus">Väljastatavate arvude arv</param>
        /// <param name="parameetrid">Kaks reaalarvu - miinimum ja maksimum</param>
        /// <returns></returns>
        Random r = new Random();
        public double[] createRandomNumbers(int copys, params double[] maxandmin)
        {
            if (maxandmin.Length != 2) { throw new Exception("Puuduvad miinimum ja maksimum"); }
            double[] resultSet = new double[copys];
            for (int i = 0; i < copys; i++) {
                resultSet[i] = r.NextDouble() * (maxandmin[1] - maxandmin[0]) + maxandmin[0];
            }
            return resultSet;
        }

        // We require EF Model to be given to us
        public void saveGenerated(generationHistorySet resultInput)
        {
            resultInput.Id = Guid.NewGuid();

            // After we are finished with this, we dispose it
            // katselaborEntities is our edmx reference
            using (var ctx = new katselaborEntities())
            {
                ctx.generationHistorySets.Add(resultInput);                
                ctx.SaveChanges();

                logger.Info("Saving to db " + resultInput.result);
            }
        }
    }
}
