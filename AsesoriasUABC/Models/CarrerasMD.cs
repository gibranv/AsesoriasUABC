using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.Models
{
    [MetadataType(typeof(Validation_carreras))]
    public partial class carreras
    {

    }
    public class Validation_carreras
    {
        public int id_carrera { get; set; }
        [Display(Name ="Codigo")]
        public int codigo { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
    }
 
}