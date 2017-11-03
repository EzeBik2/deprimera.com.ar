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
        public int CantJug { get; set; }        
        public int Calificacion { get; set; }        
        public int Cantvotos { get; set; }
        public int IDCanchaPreferida { get; set; }
        public int IDCamisetaPreferida { get; set; }
        public string Descripcion { get; set; }
        public string SEPUEDE { get; set; }
    }
}