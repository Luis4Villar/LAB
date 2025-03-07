namespace Personas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelPerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "Identificacion", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "Identificacion", c => c.String());
        }
    }
}
