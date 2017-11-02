using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deprimera.com.ar.Models
{
    public class Partido
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCancha { get; set; }
        public Cancha Cancha { get; set; }
        public int CantJug { get; set; }
        public List<PartidoJugador> ListaDeJugadores {get; set;}
        public int IdCamiseta1 { get; set; }
        public int IdCamiseta2 { get; set; }
        public int Duracion { get; set; }
        public string SEPUEDE { get; set; }
        public string Funciono { get; set; }
    }
}