using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsesoriasUABC.ViewModels
{
    public class AsesoriaModelView
    {
        public int id_Alumno { get; set; }
        public int id_materia { get; set; }
        public int id_Tema { get; set; }
        public int id_asesor { get; set; }
        public DateTime fecha { get; set; }
        public int matricula { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public int cvc { get; set; }
        public int Grupo { get; set; }

    }
}