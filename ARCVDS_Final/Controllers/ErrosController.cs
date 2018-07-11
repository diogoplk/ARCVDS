using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARCVDS_Final.Controllers
{
    public class ErrosController : Controller
    {
        // GET: Erros
        public ActionResult Index() {
            return View();
        }
        public ActionResult Erro404() {
                return View ();
        }
        public ActionResult AcessoRestrito() {
                return View ();
        }
        public ActionResult Indisponivel() {
                return View ();
        }
    }
}