using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using katselabor.Generaatorid;
using NLog;

namespace katselabor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
            IArvudeGeneraator generaator = new YhtlaseJaotusegaGeneraator();
            //ViewBag.arvud = new double[] { 21.65, 11.25 };
            ViewBag.arvud = generaator.looArvud(Convert.ToInt32(id), min, 30);

            logger.Trace("Sample trace message");
            logger.Debug("Sample debug message");
            logger.Info("Sample informational message");
            logger.Warn("Sample warning message");
            logger.Error("Sample error message");
            logger.Fatal("Sample fatal error message");

            return View();
        }
    }
}