using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.Models
{
    [MetadataType(typeof(AsesoriasTb_Validation))]
    public partial class AsesoriasTb
    {
    }
    public class AsesoriasTb_Validation
    {
       [Display(Name ="Asesor")]
       public Nullable<int> id_asesor { get; set; }

       [Display(Name ="Materia")]
       public Nullable<int> id_materia { get; set; }
       [Display(Name = "Cantidad de veces cursadas")] 
       public string cvc { get; set; }
    }
}