namespace Personas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "Identificacion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "Identificacion", c => c.Int(nullable: false));
        }
    }
}
