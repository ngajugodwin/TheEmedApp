﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eMed.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class emedEntities : DbContext
    {
        public emedEntities()
            : base("name=emedEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<bill_details> bill_details { get; set; }
        public virtual DbSet<casenote> casenotes { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<messaging> messagings { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<qm_sop> qm_sop { get; set; }
        public virtual DbSet<qm_tree> qm_tree { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<service_catalog> service_catalog { get; set; }
        public virtual DbSet<temp_search> temp_search { get; set; }
        public virtual DbSet<temp_service> temp_service { get; set; }
        public virtual DbSet<template> templates { get; set; }
        public virtual DbSet<time_recording> time_recording { get; set; }
        public virtual DbSet<time_recording_details> time_recording_details { get; set; }
        public virtual DbSet<time_recording_type> time_recording_type { get; set; }
        public virtual DbSet<user_detail> user_detail { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
