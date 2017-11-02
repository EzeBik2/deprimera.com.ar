using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace deprimera.com.ar.Models
{
    public class EquipoJugador
    {
        public int ID { get; set; }
        public string Estado { get; set; }
        public string Rol { get; set; }
        public int IdEquipo { get; set; }
        public int IdJugador { get; set; }
    }
}