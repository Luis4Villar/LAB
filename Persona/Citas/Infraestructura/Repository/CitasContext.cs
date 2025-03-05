using Citas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Citas.Infraestructura.Repository
{
	public class CitasContext : DbContext
	{
		public CitasContext(): base("name=Citas")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}

		public DbSet<CitasM> Citas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			modelBuilder.Entity<CitasM>().ToTable("Cita");
            base.OnModelCreating(modelBuilder);
        }
    }
}