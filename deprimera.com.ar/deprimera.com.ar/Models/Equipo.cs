using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace deprimera.com.ar.Models
{
    public class Equipo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Cantjug { get; set; }
        public List<EquipoJugador> ListaDeJugadores { get; set; }
        public int Calificacion { get; set; }
        public int Cantvotos { get; set; }
        public string Funciono { get; set; }
        public int IdCanchaPreferida { get; set; }
        public int IdCamisetaPreferida { get; set; }
        public string Descripcion { get; set; }
        public string SEPUEDE { get; set; }
    }
}