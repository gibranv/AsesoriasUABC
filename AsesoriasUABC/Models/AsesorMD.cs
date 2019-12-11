using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.Models
{
    [MetadataType(typeof(Asesor_Validation))]
    public partial class AsesoresTb
    {

    }
    public class Asesor_Validation
    {
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name ="Apellido paterno")]
        public string ApellidoP { get; set; }
        [Required]
        [Display(Name ="Codigo de empleado")]
        public int codigo_empleado { get; set; }
        [Required]
        [Display(Name ="Correo electronico")]
        public string correo { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public string sexo { get; set; }
        [Display(Name ="Apellido materno")]
        public string ApellidoM { get; set; } 
    }
}