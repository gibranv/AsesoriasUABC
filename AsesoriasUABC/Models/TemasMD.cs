using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.Models
{

    [MetadataType(typeof(Validation_Temas))]
    public partial class temasTb
    {
    }
    public class Validation_Temas
    {
        
        [Display(Name="Numero de tema")]
        [Required]
        public string numero_tema { get; set; }
        [Display(Name = "Tema")]
        [Required]
        public string nombre_tema { get; set; }     
        [Required]
        [Display(Name ="Materia")]  
        public Nullable<int> id_Materias { get; set; }
    }
}