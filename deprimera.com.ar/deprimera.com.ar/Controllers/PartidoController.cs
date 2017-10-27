using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deprimera.com.ar.Models;

namespace deprimera.com.ar.Controllers
{
    public class PartidoController : Controller
    {
        public ActionResult PerfilPartido()
        {
            return View();
        }

        public ActionResult IrAPerfilPartido(Jugador JugadorLogueado)
        {
            ViewBag.JugadorLog = JugadorLogueado;
            return View("PerfilPartido");
        }
    }
}
