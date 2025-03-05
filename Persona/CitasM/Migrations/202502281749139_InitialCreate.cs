namespace Personas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        IdPaciente = c.Int(nullable: false, identity: true),
                        TipoIdentificacion = c.String(),
                        Identificacion = c.Int(nullable: false),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                    })
                .PrimaryKey(t => t.IdPaciente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persona");
        }
    }
}
