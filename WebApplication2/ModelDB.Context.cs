﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_hotelEntities : DbContext
    {
        public db_hotelEntities()
            : base("name=db_hotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tDolzhnost> tDolzhnost { get; set; }
        public virtual DbSet<tInventar_nomerov> tInventar_nomerov { get; set; }
        public virtual DbSet<tKlient> tKlient { get; set; }
        public virtual DbSet<tNomer> tNomer { get; set; }
        public virtual DbSet<tResursy> tResursy { get; set; }
        public virtual DbSet<tSotrudnik> tSotrudnik { get; set; }
        public virtual DbSet<tBron_nomera> tBron_nomera { get; set; }
        public virtual DbSet<tRaskhod_resursov> tRaskhod_resursov { get; set; }
    }
}