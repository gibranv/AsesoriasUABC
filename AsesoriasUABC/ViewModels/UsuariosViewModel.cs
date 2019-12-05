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
        public Nullable<int> id_user { get; set; }
        public string id_AspUser { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name ="Apellido paterno")]
        public string ApellidoP { get; set; }
        [Display(Name ="Apellido materno")]
        public string ApellidoM { get; set; }
        [Required]
        [Display(Name ="Codigo de empleado")]
        public int codigo_Empleado { get; set; }
        [Required]
        public string sexo { get; set; }
        public bool estatus { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string contraseña { get; set; }

        public bool Director { get; set; }
        public bool Subdirector { get; set; }
        public bool Coordinador { get; set; }
        public bool Profesor { get; set; }
        public bool Secretario { get; set; }
        public bool Becario { get; set; }
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
        public List<string> GetRoles() {
            List<string> s = new List<string>();
            if (this.Becario)
                s.Add("Becario");
            if (this.Secretario)
                s.Add("Secretario");
            if (this.Profesor)
                s.Add("Profesor");
            if (this.Coordinador)
                s.Add("Coordinado");
            if (this.Director)
                s.Add("Director");
            if (this.Subdirector)
                s.Add("Subdirector");
                  

            return s;
        }
    }
}