using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsesoriasUABC.ViewModels
{
    public class AsesoriaModelView
    {
        public int id_Alumno { get; set; }
        [Display(Name = "Materia")]
        public int id_materia { get; set; }
        [Display(Name = "Tema")]
        public int id_Tema { get; set; }
        [Display(Name = "Asesor")]
        public int id_asesor { get; set; }
        public DateTime fecha { get; set; }
        public int matricula { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        [Display (Name= "Cantidad de veces cursada") ]
        public int cvc { get; set; }
        public int Grupo { get; set; }
       
         
    }
}