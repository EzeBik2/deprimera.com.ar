using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deprimera.com.ar.Models
{
    public class Partido
    {
        public int id { get; set; }

        public DateTime Fecha { get; set; }

        public int CantJug { get; set; }

        public int IdCancha { get; set; }

        public string Funciono { get; set; }
    }
}