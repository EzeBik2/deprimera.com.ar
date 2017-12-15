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
        public ActionResult IrAPerfilPartido(Partido unPartido)
        {
            Jugador JugadorLogueado = new Jugador();
            JugadorLogueado.ID = unPartido.ID;
            JugadorLogueado = Jugadores.TraerUnJugadorPorID(JugadorLogueado.ID);
            
            ViewBag.JugadorLog = JugadorLogueado; //ENVIA DATOS DEL JUGADOR LOGUEADO A VISTA
            unPartido.Cancha = Canchas.TraerCanchaPorId(unPartido.IdCancha);
            ViewBag.Partido = unPartido;
            return View("PerfilPartido"); //RETORNA AL PERFIL DEL PARTIDO
        }
        public ActionResult CrearPartido(Jugador unJugador)
        {
            Partido PartidoEnBlanco = new Partido();
            PartidoEnBlanco = Partidos.ArmarPartido(PartidoEnBlanco); //AGREGA UN PARTIDO EN BLANCO A LA BD

            PartidoJugador AgregarJugadorAPartido = new PartidoJugador();
            AgregarJugadorAPartido.IdPartido = PartidoEnBlanco.ID;
            AgregarJugadorAPartido.IdJugador = unJugador.ID;
            AgregarJugadorAPartido.Rol = "Admin";
            AgregarJugadorAPartido.Estado = "Titular";
            AgregarJugadorAPartido.NombreJugador = unJugador.Nombre;
            PartidosJugadores.AgregarJugadorAPartido(AgregarJugadorAPartido); //AGREGA AL JUGADOR A PARTIDO Y LO HACE ADMIN

            PartidoEnBlanco.ID = unJugador.ID;
            PartidoEnBlanco.ListaDeJugadores = new List<PartidoJugador>();
            PartidoEnBlanco.ListaDeJugadores.Add(AgregarJugadorAPartido); //AGREGA AL JUGADOR A LA LISTA DE LOS JUGADORES DEL EQUIPO LOCAL

            return IrAPerfilPartido(PartidoEnBlanco); //RETORNA AL PERFIL EQUIPO
        }
        public ActionResult ModificarPartido(ModificarPartido unObjeto) //SE EJECUTA AL PRESIONAR CONTINUAR
        {
            unObjeto.unPartido = Partidos.ModificarPartidoPorID(unObjeto.unPartido); //MODIFICA TODOS LOS DATOS DEL PARTIDO DE LA BD

            foreach (PartidoJugador jugador in unObjeto.unPartido.ListaDeJugadores)
            {
                PartidosJugadores.ModificarPartidoJugador(jugador); //MODIFICA TODAS LOS PARTIDOSJUGADORES DEL PARTIDO DE LA BD PARA ACTUALIZAR SUS ROLES Y ESTADOS
            }

            HomeController Controlador = new HomeController();
            return Controlador.IrAPartido(unObjeto.unJugador); //RETORNA A PARTIDO
        }
        public ActionResult EntrarAPartido(PartidoJugador unJugador) //SE EJECUTA CUANDO UN USUARIO ENTRA A UN PARTIDO YA CREADO
        {
            if (PartidosJugadores.TraerPartidoJugadorPorIDs(unJugador.IdPartido, unJugador.IdJugador).ID > 0) //VERIFICA QUE EL JUGADOR NO PERTENEZCA AL PARTIDO
            {
                PartidosJugadores.AgregarJugadorAPartido(unJugador); //AGREGA AL JUGADOR AL PARTIDO
            }

            Partido PartidoAEntrar = new Partido();
            PartidoAEntrar.ID = unJugador.IdPartido;
            PartidoAEntrar = Partidos.TraerPartidoPorID(PartidoAEntrar.ID); //TRAE LOS DATOS DEL PARTIDO
            PartidoAEntrar.ListaDeJugadores = PartidosJugadores.TraerJugadores(PartidoAEntrar.ID); //TRAE LA LISTA DE JUGADORES DEL PARTIDO
            PartidoAEntrar.ID = unJugador.IdJugador; //PONGO EL ID DEL JUGADOR LOGUEADO EN EL ID DEL PARTIDO

            return IrAPerfilPartido(PartidoAEntrar); //RETORNA A PERFIL PARTIDO
        }
        public ActionResult EliminarPartido(Partido unPartido, Jugador unJugador) //SE EJECUTA CUANDO EL ULTIMO JUGADOR DEL PARTIDO SALE DEL PARTIDO O CUANDO EL ADMINISTRADOR DEL PARTIDO BORRA EL PARTIDO
        {
            Partidos.EliminarPartidoPorID(unPartido); //ELIMINA EL PARTIDO DE LA BD
            foreach (PartidoJugador jugador in unPartido.ListaDeJugadores)
            {
                PartidosJugadores.Eliminar(jugador); //ELIMINA A LOS JUGADORES DEL PARTIDO
            }

            HomeController Controlador = new HomeController();
            return Controlador.IrAPartido(unJugador); //RETORNA A PARTIDO
        }
        public ActionResult SalirDelPartido(PartidoJugador unJugador) //SE EJECUTA CUANDO UN JUGADOR SALE DEL PARTIDO
        {
            PartidosJugadores.Eliminar(unJugador); //ELIMINA AL JUGADOR DEL PARTIDO

            Jugador jugador = new Jugador();
            jugador.ID = unJugador.IdJugador; //CARGA DATOS DEL JUGADOR

            HomeController Controlador = new HomeController();
            return Controlador.IrAPartido(jugador); //RETORNA A PARTIDO
        }

        public ActionResult Opciones(ModificarPartido unObjeto)
        {
            ViewBag.Partido = unObjeto.unPartido;
            ViewBag.Jugador = unObjeto.unJugador;

            return View();
        }

        //public ActionResult IrAMisPartidos(Jugador unJugador)
        //{
        //    PartidoJugador unPartidoJugador = new PartidoJugador();
        //    unPartidoJugador.IdJugador = unJugador.ID;
        //    List<PartidoJugador> Lista = PartidosJugadores.TraerPartidos(unPartidoJugador);
        //    foreach (PartidoJugador PartJug in Lista)
        //    {
        //        PartJug.Fecha = Partidos.TraerPartidoPorID(PartJug.IdPartido).Fecha;
        //        PartJug.Cancha = Canchas.TraerCanchaPorId(Partidos.TraerPartidoPorID(PartJug.IdPartido).IdCancha).Nombre;
        //    }
        //    ViewBag.Lista = Lista;
        //    return View("MisPartidos");
        //}
        //public ActionResult IrAPartidosConVacantes(Jugador unJugador)
        //{
        //    List<Partido> Lista = Partidos.TraerTodos();
        //    foreach (Partido PartJug in Lista)
        //    {
        //        PartidoJugador unParti = new PartidoJugador();
        //        unParti.IdPartido = PartJug.ID;
        //        unParti.IdJugador = unJugador.ID;
        //        if (PartidosJugadores.TraerPartidoJugadorPorIDs(unParti).ID > 0)
        //        {
        //            Lista.Remove(PartJug);
        //        }
        //        else
        //        {
        //            PartJug.Cancha = Canchas.TraerCanchaPorId(PartJug.IdCancha);
        //        }
        //    }
        //    ViewBag.Lista = Lista;
        //    ViewBag.JugadorLog = unJugador;
        //    return View("PartidosConVacantes");
        //}
    }
}
