using System.Web.Mvc;

namespace ARCVDS_Final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Eventos() {
            ViewBag.Message = "Página de Eventos";

            return View ();
        }

        public ActionResult Beneficios() {
            ViewBag.Message = "Página dos Beneficios";

            return View ();
        }

    }
}
