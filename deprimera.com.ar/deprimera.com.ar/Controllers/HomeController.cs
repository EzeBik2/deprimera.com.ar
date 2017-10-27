using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deprimera.com.ar.Models;

namespace deprimera.com.ar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LandingPage()
        {
            return View();
        }
        public ActionResult Loguearse(Jugador jugadorqueseestalogueando)
        {
            jugadorqueseestalogueando = Jugadores.TraerUnJugador(jugadorqueseestalogueando); //Verifica que exista el jugador, devuelve un jugador
            if (jugadorqueseestalogueando.id > 0)
            {
                return IrAIndex(jugadorqueseestalogueando); //Si el jugador devuelto tiene un id valido, existe y ejecuta el metodo Logueado
            }
            else
            {
                ViewBag.Error = jugadorqueseestalogueando.Confcontraseña;
                return View("LandingPage"); //Si el jugador devuelto no tiene un id valido, no existe y vuelve a index enviando mensaje de error
            }
        }
        public ActionResult IrAIndex(Jugador jugadorqueseestalogueando)
        {
            //ViewBag.Combobox = Canchas.TraerNombresDeTodasLasCanchas(); //Trae la lista de todas las canchas que existen

            //Traer Listas
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Index"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult IrAPartido(Jugador jugadorqueseestalogueando)
        {
            //ViewBag.Combobox = Canchas.TraerNombresDeTodasLasCanchas(); //Trae la lista de todas las canchas que existen

            //Traer Listas
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Partido"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult IrAEquipo(Jugador jugadorqueseestalogueando)
        {
            //ViewBag.Combobox = Canchas.TraerNombresDeTodasLasCanchas(); //Trae la lista de todas las canchas que existen

            //Traer Listas
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Equipo"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult IrABuscar(Jugador jugadorqueseestalogueando)
        {
            //ViewBag.Combobox = Canchas.TraerNombresDeTodasLasCanchas(); //Trae la lista de todas las canchas que existen

            //Traer Listas
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Buscar"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult Registrarse(Jugador jugadorqueseestaregistrando)
        {
            jugadorqueseestaregistrando = Jugadores.RegistrarJugador(jugadorqueseestaregistrando);
            if (jugadorqueseestaregistrando.id > 0)
            {
                return IrAIndex(jugadorqueseestaregistrando);
            }
            else
            {
                ViewBag.Error = jugadorqueseestaregistrando.Confcontraseña;
                return View("LandingPage"); //Si el jugador devuelto no tiene un id valido, no existe y vuelve a index enviando mensaje de error
            }
        }
    }
}