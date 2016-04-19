using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using katselabor.Interfaces;
using katselabor.Repos;
using NLog;

namespace katselabor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //logger.Trace("Sample trace message");
            //logger.Debug("Sample debug message");
            //logger.Info("Sample informational message");
            //logger.Warn("Sample warning message");
            //logger.Error("Sample error message");
            //logger.Fatal("Sample fatal error message");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Arvuloetelu(int id, double min=5) {

            // Accessing repository for our data
            IArvudeGeneraator generaator = new YhtlaseJaotusegaGeneraator();

            // Storing data in private variable for function use only
            double[] arvud = generaator.createRandomNumbers(Convert.ToInt32(id), min, 30);

            // Saving same data to DB using EF from repo
            generationHistorySet resultSet = new generationHistorySet();
            resultSet.result = Convert.ToString(arvud);
            generaator.saveGenerated(resultSet);

            // Displaying to view
            //ViewBag.arvud = new double[] { 21.65, 11.25 };
            ViewBag.arvud = arvud;

            // How many did we generate again? 
            logger.Info("We created " + id + " numbers");

            return View();
        }
    }
}