﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stepan.Repository.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StepanEktron_oldEntities : DbContext
    {
        public StepanEktron_oldEntities()
            : base("name=StepanEktron_oldEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<country_tbl> country_tbl { get; set; }
        public DbSet<ProductFinder> ProductFinders { get; set; }
        public DbSet<ProductFinderLink> ProductFinderLinks { get; set; }
        public DbSet<ProductFinderTaxonomy> ProductFinderTaxonomies { get; set; }
        public DbSet<ProductTaxonomySummary> ProductTaxonomySummaries { get; set; }
        public DbSet<region_tbl> region_tbl { get; set; }
        public DbSet<SalesOffice> SalesOffices { get; set; }
        public DbSet<SalesOfficeServiceLocation> SalesOfficeServiceLocations { get; set; }
    }
}
