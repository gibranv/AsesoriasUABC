﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBAsesoriasFIADEntities : DbContext
    {
        public DBAsesoriasFIADEntities()
            : base("name=DBAsesoriasFIADEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AlumnosTb> AlumnosTb { get; set; }
        public virtual DbSet<AsesoresTb> AsesoresTb { get; set; }
        public virtual DbSet<AsesoriasTb> AsesoriasTb { get; set; }
        public virtual DbSet<MateriasTb> MateriasTb { get; set; }
        public virtual DbSet<temasTb> temasTb { get; set; }
        public virtual DbSet<carreras> carreras { get; set; }
    }
}
