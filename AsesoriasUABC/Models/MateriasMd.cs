using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.Models
{
    [MetadataType(typeof(Validation_Materias))]
    public partial class MateriasTb
    {
    }
    public class Validation_Materias
    {

        public int id_materia { get; set; }
        [Display(Name ="Materia")]
        [Required]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Clave")]
        public int clave_materia { get; set; }
        [Required]
        [Display(Name = "Plan de estudios")]
        public string plan_estudios { get; set; }
    }
}