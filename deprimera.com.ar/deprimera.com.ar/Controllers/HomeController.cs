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
        public ActionResult VieneDeLanding(Landing Objeto)
        {
            if (Objeto.unaCancha.Nombre.Length > 0)
            {
                return AfiliarCancha(Objeto.unaCancha);
            }
            else
            {
                if (Objeto.unJugador.Nombre.Length > 0)
                {
                    return Registrarse(Objeto.unJugador);
                }
                else
                {
                    return Ingresar(Objeto.unJugador);
                }
            }
        }
        public ActionResult IrAIndex(Jugador jugadorqueseestalogueando)
        {
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Index"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult IrAPartido(Jugador jugadorqueseestalogueando)
        {
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Partido"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult IrAEquipo(Jugador jugadorqueseestalogueando)
        {
            //TRAER LISTA DE MIS EQUIPOS + LISTA DE EQUIPOS CON VACANTES
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Equipo"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult IrABuscar(Jugador jugadorqueseestalogueando)
        {
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Buscar"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult IrAChat(Jugador jugadorqueseestalogueando)
        {
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Chat"); //Si fallo el programa que vuelva a inicio.
        }
        public ActionResult Ingresar(Jugador jugadorqueseestalogueando)
        {
            jugadorqueseestalogueando = Jugadores.TraerUnJugadorPorEmailClave(jugadorqueseestalogueando); //Verifica que exista el jugador, devuelve un jugador
            if (jugadorqueseestalogueando.ID > 0)
            {
                return IrAIndex(jugadorqueseestalogueando); //Si el jugador devuelto tiene un id valido, existe y ejecuta el metodo Logueado
            }
            else
            {
                return View("LandingPage"); //Si el jugador devuelto no tiene un id valido, no existe y vuelve a index enviando mensaje de error
            }
        }
        public ActionResult Registrarse(Jugador jugadorqueseestaregistrando)
        {
            jugadorqueseestaregistrando = Jugadores.AgregarJugador(jugadorqueseestaregistrando);
            if (jugadorqueseestaregistrando.ID > 0)
            {
                return IrAIndex(jugadorqueseestaregistrando);
            }
            else
            {
                return View("LandingPage"); //Si el jugador devuelto no tiene un id valido, no existe y vuelve a index enviando mensaje de error
            }
        }
        public ActionResult AfiliarCancha(Cancha cancharegistrar)
        {
            Canchas.AgregarCancha(cancharegistrar);
            return LandingPage();
        }
    }
}