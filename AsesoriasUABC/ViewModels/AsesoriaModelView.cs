using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AsesoriasUABC.Models.Constants;

namespace AsesoriasUABC.ViewModels
{
    public class AsesoriaModelView
    {
        public int id_Alumno { get; set; }
        [Required(ErrorMessage = "Seleccione una materia")]
        [Display(Name = "Materia")]
        public int id_materia { get; set; }
        [Required(ErrorMessage = "Seleccione un tema")]
        [Display(Name = "Tema")]
        public int id_Tema { get; set; }
        [Required(ErrorMessage = "Seleccione un asesor")]
        [Display(Name = "Asesor")]
        public int id_asesor { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha valida con formato dd/mm/aa")]
        public DateTime fecha { get; set; }
        [Required(ErrorMessage = "Es necesario llenar campo matricula")]
        [Range(100000,9999999, ErrorMessage = "Ingrese un numero valido")] 
        public int matricula { get; set; }
        //[Required(ErrorMessage = "Es necesario agregar nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es necesario agregar carrera")]
        public string Carrera { get; set; }
        [Required(ErrorMessage = "Ingrese un cvc valido")]
        [Display(Name = "Cantida de veces cursada")]
        public Cvc cvc { get; set; }
        [Required(ErrorMessage = "Ingrese un grupo valido")]
        [Range( 100, 999, ErrorMessage = "Ingrese un numero valido")]
        public int Grupo { get; set; }


    }
}