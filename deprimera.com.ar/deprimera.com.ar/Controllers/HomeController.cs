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
            //Traer Listas
            ViewBag.jugadorqueselogueo = jugadorqueseestalogueando;
            return View("Index"); //Si fallo el programa que vuelva a inicio.
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

        public ActionResult BuscarTodo(Todos ABuscar)
        {
            Jugador mijugador = new Jugador();
            mijugador.id = ABuscar.id;
            ViewBag.JugadorLogueado = Jugadores.TraerUnJugador(mijugador); //Envia Jugador logueado

            string Id = ABuscar.nombre;
            if (Id.Substring(0, 1) == "#")
            {
                switch (Id.Substring(1, 1))
                {
                    case "C":
                        IrAPerfilCancha(Id);
                        return View("PerfilCancha");
                    case "E":
                        IrAPerfilEquipo(Id);
                        return View("PerfilEquipo");
                    case "J":
                        IrAPerfilJugador(Id);
                        return View("PerfilJugador");
                    case "P":
                        IrAPerfilPartido(Id);
                        return View("PerfilPartido");
                    default:
                        return View("Logueado");
                }
            }
            else
            {
                List<Todos> ListadeResultados = new List<Todos>(); //Lista de resultados de la busqueda a mostrar

                Equipo EquipoABuscar = new Equipo(); 
                EquipoABuscar.nombre = Id;
                List<Equipo> Listadeequiposencontrados = Equipos.TraerEquiposPorNombre(EquipoABuscar); //Lista de Equipos que contienen ese nombre
                for (int i = 0; i < Listadeequiposencontrados.Count; i++) //Con este for se agrega a la lista de resultados los equipos que contienen ese nombre
                {
                    Todos EquipoEncontrado = new Todos(); //Convierto El Equipo de la lista de objeto EQUIPO a objeto TODOS
                    EquipoEncontrado.id = Listadeequiposencontrados[i].id;
                    EquipoEncontrado.nombre = Listadeequiposencontrados[i].nombre;
                    EquipoEncontrado.tipo = "Equipo"; 
                    if (EquipoEncontrado.id != 0)
                    {
                        ListadeResultados.Add(EquipoEncontrado); //Agrega a la lista
                    }
                }

                Cancha CanchaABuscar = new Cancha();
                CanchaABuscar.nombre = Id;
                List<Cancha> Listadecanchasencontradas = Canchas.TraerCanchasPorNombre(CanchaABuscar); //Lista de Canchas que contienen ese nombre
                for (int i = 0; i < Listadecanchasencontradas.Count; i++) //Con este for se agrega a la lista de resultados las canchas que contienen ese nombre
                {
                    Todos CanchaEncontrada = new Todos(); //Convierto La Cancha de la lista de objeto CANCHA a objeto TODOS
                    CanchaEncontrada.id = Listadecanchasencontradas[i].id;
                    CanchaEncontrada.nombre = Listadecanchasencontradas[i].nombre;
                    CanchaEncontrada.tipo = "Cancha";
                    if (CanchaEncontrada.id != 0)
                    {
                        ListadeResultados.Add(CanchaEncontrada); //Agrega a la lista
                    }
                }

                Jugador JugadorABuscar = new Jugador();
                JugadorABuscar.nombre = Id;
                List<Jugador> Listadejugadoresencontrados = Jugadores.TraerJugadoresPorNombre(JugadorABuscar); //Lista de Jugadores que contienen ese nombre
                for (int i = 0; i < Listadejugadoresencontrados.Count; i++) //Con este for se agrega a la lista de resultados los jugadores que contienen ese nombre
                {
                    Todos JugadorEncontrado = new Todos(); //Convierto el Jugador de la lista de objeto JUGADOR a objeto TODOS
                    JugadorEncontrado.id = Listadejugadoresencontrados[i].id;
                    JugadorEncontrado.nombre = Listadejugadoresencontrados[i].nombre;
                    JugadorEncontrado.tipo = "Jugador";
                    if (JugadorEncontrado.id != 0)
                    {
                        ListadeResultados.Add(JugadorEncontrado); //Agrega a la lista
                    }
                }

                ViewBag.listaderesultados = ListadeResultados; //Envio los resultados a una Vista para mostrar la Lista en una Tabla
                return View("Todos");
            }
        }
        public ActionResult IrAPerfilCancha(string IddeCancha)
        {
            //FALTA QUE TRAIGA TODOS LOS PARTIDOS DE LA CANCHA CON VALIDACION PARA QUE QUITE TODOS LOS INVALIDOS
            Cancha Canchaabuscar = new Cancha();
            Canchaabuscar.id = Convert.ToInt32(IddeCancha.Substring(2, IddeCancha.Length - 2)); //Id de Base de Datos de la Cancha
            Canchaabuscar = Canchas.TraerUnaCanchaPorId(Canchaabuscar); //Trae de la base de datos la Cancha
            ViewBag.PerfilCancha = Canchaabuscar; //Envia la cancha buscada
            return View("PerfilCancha");
        }
        public ActionResult IrAPerfilEquipo(string IddeEquipo)
        {
            //FALTA QUE TRAIGA LA LISTA DE JUGADORES DEL EQUIPO CON VALIDACION PARA QUE QUITE TODOS LOS INVALIDOS
            Equipo Equipoabuscar = new Equipo();
            Equipoabuscar.id = Convert.ToInt32(IddeEquipo.Substring(2, IddeEquipo.Length - 2));
            Equipoabuscar = Equipos.TraerUnEquipoPorId(Equipoabuscar);
            ViewBag.PerfilEquipo = Equipoabuscar;
            return View("PerfilEquipo");
        }
        public ActionResult IrAPerfilJugador(string IddeJugador)
        {
            //FALTA QUE TRAIGA LOS EQUIPOS, PARTIDOS Y DESAFIOS SIN CANCHA Y LISTA DE AMIGOS DEL JUGADOR CON VALIDACION PARA QUE QUITE TODOS LOS INVALIDOS
            Jugador JugadorABuscar = new Jugador();
            JugadorABuscar.id = Convert.ToInt32(IddeJugador.Substring(2, IddeJugador.Length - 2));
            JugadorABuscar = Jugadores.TraerUnJugador(JugadorABuscar);
            ViewBag.A = JugadorABuscar;
            return View("PerfilJugador");
        }
        public ActionResult IrAPerfilPartido(string IddePartido)
        {
            //FALTA QUE TRAIGA LISTA DE JUGADORES DEL PARTIDO CON VALIDACION PARA QUE QUITE TODOS LOS INVALIDOS
            Partido PartidoABuscar = new Partido();
            PartidoABuscar.id = Convert.ToInt32(IddePartido.Substring(2, IddePartido.Length - 2));
            PartidoABuscar = Partidos.TraerUnPartido(PartidoABuscar);
            ViewBag.A = PartidoABuscar;
            return View("PerfilPartido");
        }

        public ActionResult ArmarPartido(Todos partidoaarmar)
        {
            // FALTA COMPROBAR HORARIOS DE LOS USUARIOS Y DE LAS CANCHAS
            Partido unPartido2 = new Partido();
            unPartido2.CantJug = partidoaarmar.cantjug;
            unPartido2.Fecha = partidoaarmar.fecha;

            Cancha canchadelPartido = new Cancha(); //Traigo el ID de la cancha del partido
            canchadelPartido.nombre = partidoaarmar.canchas[0];
            canchadelPartido = Canchas.TraerCancha(canchadelPartido);
            unPartido2.IdCancha = canchadelPartido.id;

            unPartido2 = Partidos.ArmarPartido(unPartido2); //Agrego el partido a la BD y Traigo el partido con su ID

            PartidoJugador crearrelacionpartidojugador = new PartidoJugador();
            crearrelacionpartidojugador.idJugador = partidoaarmar.id;
            crearrelacionpartidojugador.idPartido = unPartido2.id;
            string Error = PartidosJugadores.AgregarJugadorAPartido(crearrelacionpartidojugador); //Agrego el jugador a el partido

            if (Error == null && unPartido2.Funciono == null && canchadelPartido == null) //Se fija si hubo errores
            {
                Todos PerfilPartido = new Todos();
                PerfilPartido.id = partidoaarmar.id;
                PerfilPartido.nombre = "#P" + unPartido2.id;
                return BuscarTodo(PerfilPartido);                                      //Muestra el perfil del partido
            }
            else                                                                       //Si hubo errores los muestra en la pantalla de Index
            {
                ViewBag.Error = canchadelPartido.nombre;
                ViewBag.Error2 = unPartido2.Funciono;
                ViewBag.Error3 = Error;
                Jugador UsuarioLogueado = new Jugador();
                UsuarioLogueado.id = partidoaarmar.id;
                return IrAIndex(UsuarioLogueado);
            }            
        }
        public ActionResult ArmarEquipo(Todos equipoaarmar)
        {
            //FALTA COMPROBAR SI EXISTE EL NOMBRE DEL EQUIPO
            Equipo unEquipo = new Equipo();
            unEquipo.nombre = equipoaarmar.nombre;
            unEquipo.cantjug = equipoaarmar.cantjug;
            unEquipo = Equipos.ArmarEquipo(unEquipo); //Agrego el equipo a la BD y Traigo el equipo con su ID
            if (unEquipo.Funciono != null)
            {
                ViewBag.Error = unEquipo.Funciono;
            }

            EquipoJugador crearrelacionequipojugador = new EquipoJugador();
            crearrelacionequipojugador.idJugador = equipoaarmar.id;
            crearrelacionequipojugador.idEquipo = unEquipo.id;
            string Error = EquiposJugadores.AgregarJugadorAEquipo(crearrelacionequipojugador);
            if (Error != null)
            {
                ViewBag.Error2 = Error;
            }

            if (Error == null && unEquipo.Funciono == null)
            {
                //Ir a Perfil con Buscar Todo y Enviar Datos
            }
            Jugador JTH = new Jugador();
            JTH.id = equipoaarmar.id;
            return IrAIndex(JTH);
        }
    }
}