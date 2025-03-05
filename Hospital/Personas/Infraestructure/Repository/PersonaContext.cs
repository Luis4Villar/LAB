using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Personas.Infraestructure.Repository
{
    public class PersonaContext : DbContext
    {
        public PersonaContext() : base("name=Personas")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("Persona");
            base.OnModelCreating(modelBuilder);
        }
    }
}