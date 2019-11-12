using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsesoriasUABC.Models;
using System.ComponentModel.DataAnnotations;

namespace AsesoriasUABC.ViewModels
{
    public class UsuariosViewModel
    {
        public int id_user { get; set; }
        public string id_AspUser { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }
        [Required]
        [Display(Name ="Codigo de empleado")]
        public int codigo_Empleado { get; set; }
        [Required]
        public string sexo { get; set; }
        public int estatus { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string contraseña { get; set; }
        
        public UsuariosViewModel ()
        {

        }
        public UsuariosViewModel(Usuarios usr, ApplicationUser usrAsp)
        {
            this.id_user = usr.id_user;
            this.id_AspUser = usrAsp.Id;
            this.Nombre = usr.Nombre;
            this.ApellidoM = usr.ApellidoM;
            this.ApellidoP = usr.ApellidoP;
            this.codigo_Empleado = usr.codigo_empleado;
            this.correo = usrAsp.Email;
            this.contraseña = "";
            this.estatus = usr.estatus;
        }
    }
}