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
        //public ActionResult IrAPerfilPartido(Partido unPartido)
        //{
        //    Jugador JugadorLogueado = new Jugador();
        //    JugadorLogueado.ID = unPartido.ID;
        //    JugadorLogueado = Jugadores.TraerUnJugador(JugadorLogueado);

        //    ViewBag.JugadorLog = JugadorLogueado;
        //    return View("PerfilPartido");
        //}
        //public ActionResult CrearPartido(Jugador unJugador)
        //{
        //    Partido PartidoEnBlanco = new Partido();
        //    PartidoEnBlanco = Partidos.ArmarPartido(PartidoEnBlanco);

        //    PartidoJugador AgregarJugadorAPartido = new PartidoJugador();
        //    AgregarJugadorAPartido.IdPartido = PartidoEnBlanco.ID;
        //    AgregarJugadorAPartido.IdJugador = unJugador.ID;
        //    AgregarJugadorAPartido.Rol = "Admin";
        //    AgregarJugadorAPartido.Estado = "";
        //    PartidosJugadores.AgregarJugadorAPartido(AgregarJugadorAPartido);

        //    PartidoEnBlanco.ListaDeJugadores.Add(AgregarJugadorAPartido);
        //    return IrAPerfilPartido(PartidoEnBlanco);
        //}
        //public ActionResult ModificarPartido(Partido unPartido, Jugador unJugador)
        //{
        //    unPartido = Partidos.Modificar(unPartido);

        //    foreach (PartidoJugador jugador in unPartido.ListaDeJugadores)
        //    {
        //        PartidosJugadores.Modificar(jugador);
        //    }

        //    HomeController Controlador = new HomeController();
        //    return Controlador.IrAPartido(unJugador);
        //}
        //public ActionResult EntrarAPartido(PartidoJugador unJugador)
        //{
        //    if (!PartidosJugadores.Traer(unJugador))
        //    {
        //        PartidosJugadores.AgregarJugadorAPartido(unJugador);
        //    }            

        //    Partido PartidoAEntrar = new Partido();
        //    PartidoAEntrar.ID = unJugador.IdPartido;
        //    PartidoAEntrar = Partidos.TraerUnPartidoPorId(PartidoAEntrar);
        //    PartidoAEntrar.ListaDeJugadores = PartidosJugadores.TraerJugadores(PartidoAEntrar.ID);
        //    PartidoAEntrar.ID = unJugador.IdJugador;

        //    return IrAPerfilPartido(PartidoAEntrar);
        //}
        //public ActionResult EliminarPartido(Partido unPartido, Jugador unJugador)
        //{
        //    Partidos.Eliminar(unPartido);
        //    foreach (PartidoJugador jugador in unPartido.ListaDeJugadores)
        //    {
        //        PartidosJugadores.Eliminar(jugador);
        //    }

        //    HomeController Controlador = new HomeController();
        //    return Controlador.IrAPartido(unJugador);
        //}
        //public ActionResult SalirDelPartido(PartidoJugador unJugador)
        //{
        //    PartidosJugadores.Eliminar(unJugador);

        //    Jugador jugador = new Jugador();
        //    jugador.ID = unJugador.IdJugador;

        //    HomeController Controlador = new HomeController();
        //    return Controlador.IrAPartido(jugador);
        //}
    }
}
