namespace Citas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificacion = c.Int(nullable: false),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        FechaCita = c.DateTime(nullable: false),
                        HoraCita = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cita");
        }
    }
}
