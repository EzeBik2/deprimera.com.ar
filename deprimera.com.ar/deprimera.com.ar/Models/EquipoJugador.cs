using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace deprimera.com.ar.Models
{
    public class EquipoJugador
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string estado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int idEquipo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int idJugador { get; set; }
    }
}