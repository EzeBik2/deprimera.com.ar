using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace deprimera.com.ar.Models
{
    public class Jugador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public int DNI { get; set; }
        public int Telefono { get; set; }
        public int Calificacion { get; set; }
        public int CantidadDeVotos { get; set; }
        public string Contraseña { get; set; }
        public string ConfirmarContraseña { get; set; }
    }
}