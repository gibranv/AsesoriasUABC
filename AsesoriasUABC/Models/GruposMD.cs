using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.Models
{
    [MetadataType(typeof(Grupos_Validation))]
    public partial class Grupos
    {
    }
    public class Grupos_Validation
    {
        [Display(Name ="Grupo")]
        public int id_grupo { get; set; }
        [Display(Name ="Carrera")]
        public Nullable<int> id_carrera { get; set; }
        [Display(Name ="Numero de grupo")]
        public Nullable<int> num_grupo { get; set; }

    }
}