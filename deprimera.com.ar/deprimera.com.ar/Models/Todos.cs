﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deprimera.com.ar.Models
{
    public class Todos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public int cantjug { get; set; }
        public List<string> canchas { get; set; }
        public string tipo { get; set; }
    }
}