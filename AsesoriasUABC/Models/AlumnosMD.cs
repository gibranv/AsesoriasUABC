using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.Models
{
    [MetadataType(typeof(Validation_Alumnos))]
    public partial class AlumnosTb
    {
    }
    public class Validation_Alumnos
    {
        public int id_Alumno { get; set; }
        [Display(Name = "Matricula")]
        public int matricula { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido paterno")]
        public string apellidoP { get; set; }
        [Display(Name = "sexo")]
        public string sexo { get; set; }
        [Display(Name = "Apellido materno")]
        public string apellidoM { get; set; }
    }
}