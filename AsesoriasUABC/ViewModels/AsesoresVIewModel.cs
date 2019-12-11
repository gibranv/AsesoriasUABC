using AsesoriasUABC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.ViewModels
{
    public class AsesoresViewModel
    {
        public int Id_Asesores { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Apellido paterno")]
        public string ApellidoP { get; set; }
        [Required]
        [Display(Name = "Codigo de empleado")]
        public int codigo_empleado { get; set; }
        [Required]
        [Display(Name = "Correo electronico")]
        public string correo { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public string sexo { get; set; }
        [Display(Name = "Apellido materno")]
        public string ApellidoM { get; set; }
        public string LstGrupos { get; set; }
        public string LstMaterias { get; set; }

        public AsesoresViewModel()
        {

        }

        public AsesoresViewModel(AsesoresTb asesor)
        {
            this.Id_Asesores = asesor.Id_Asesores;
            this.nombre = asesor.nombre;
            this.sexo = asesor.sexo;
            this.ApellidoP = asesor.ApellidoP;
            this.ApellidoM = asesor.ApellidoM;
            this.codigo_empleado = asesor.codigo_empleado;
            this.correo = asesor.correo;
        }
    }
}