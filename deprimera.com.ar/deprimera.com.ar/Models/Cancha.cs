using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace deprimera.com.ar.Models
{
    public class Cancha
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Barrio { get; set; }
        public string Calle1 { get; set; }
        public string Calle2 { get; set; }
        public int Telefono { get; set; }
        public int Calificacion { get; set; }
        public int CantidadDeVotos { get; set; }
    }
}