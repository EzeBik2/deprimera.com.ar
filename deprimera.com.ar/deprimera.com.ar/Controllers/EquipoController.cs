using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deprimera.com.ar.Models;

namespace deprimera.com.ar.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult PerfilEquipo()
        {
            return View();
        }
        //    public ActionResult IrAPerfilEquipo(Equipo unEquipo)
        //    {
        //            Jugador JugadorLogueado = new Jugador();
        //            JugadorLogueado.ID = unEquipo.ID;
        //            JugadorLogueado = Jugadores.TraerUnJugador(JugadorLogueado);

        //            ViewBag.JugadorLog = JugadorLogueado; 
        //            ViewBag.Partido = unEquipo;
        //            return View("PerfilPartido");
        //    }
        //    public ActionResult CrearEquipo(Jugador unJugador)
        //    {
        //        Equipo unEquipo = new Equipo();
        //        unEquipo = Equipos.CrearEquipoEnBlanco(unEquipo);

        //        EquipoJugador AgregarJugadorAEquipo = new EquipoJugador();
        //        AgregarJugadorAEquipo.IdEquipo = unEquipo.ID;
        //        AgregarJugadorAEquipo.IdJugador = unJugador.ID;
        //        AgregarJugadorAEquipo.Rol = "Admin";
        //        AgregarJugadorAEquipo.Estado = "";
        //        EquiposJugadores.AgregarJugadorAEquipo(AgregarJugadorAEquipo);
        //        unEquipo.ListaDeJugadores.Add(AgregarJugadorAEquipo);
        //        unEquipo.ID = unJugador.ID;
        //        return IrAPerfilEquipo(unEquipo);
        //    }
        //    public ActionResult EntrarAEquipo(EquipoJugador unJugador)
        //    {
        //        if (!EquiposJugadores.TraerUnJugador(unJugador))
        //        {
        //            EquiposJugadores.AgregarJugadorAEquipo(unJugador);
        //        }
        //        Equipo unEquipo = new Equipo();
        //        unEquipo.ID = unJugador.IdEquipo;
        //        unEquipo = Equipos.TraerUnEquipoPorId(unEquipo);
        //        unEquipo.ListaDeJugadores = EquiposJugadores.TraerJugadores(unEquipo.ID);
        //        unEquipo.ID = unJugador.IdJugador;

        //        return IrAPerfilEquipo(unEquipo);
        //    }
        //    public ActionResult ModificarEquipo(Equipo unEquipo, Jugador unJugador)
        //    {
        //        unEquipo = Equipos.Modificar(unEquipo); 

        //        foreach (EquipoJugador jugador in unEquipo.ListaDeJugadores)
        //        {
        //            EquiposJugadores.Modificar(jugador); 
        //        }

        //        HomeController Controlador = new HomeController();
        //        return Controlador.IrAEquipo(unJugador);
        //    }
        //}
        //    public ActionResult EliminarEquipo(Equipo unEquipo, Jugador unJugador)
        //    {
        //        Equipos.Eliminar(unEquipo);
        //        foreach (EquipoJugador jugador in unEquipo.ListaDeJugadores)
        //        {
        //        EquiposJugadores.Eliminar(jugador); 
        //        }

        //        HomeController Controlador = new HomeController();
        //        return Controlador.IrAEquipo(unJugador); 
        //}
        //    public ActionResult SalirDeEquipo(EquipoJugador unJugador)
        //    {
        //        EquiposJugadores.Eliminar(unJugador); 

        //        Jugador jugador = new Jugador();
        //        jugador.ID = unJugador.IdJugador; 

        //        HomeController Controlador = new HomeController();
        //        return Controlador.IrAEquipo(jugador);
        //}
    }
}