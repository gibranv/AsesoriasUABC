//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsesoriasUABC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materias_Grupos
    {
        public int id_materia { get; set; }
        public int id_grupo { get; set; }
        public int id { get; set; }
        public int id_asesor { get; set; }
    
        public virtual Grupos Grupos { get; set; }
        public virtual MateriasTb MateriasTb { get; set; }
        public virtual AsesoresTb AsesoresTb { get; set; }
    }
}