namespace Personas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persona", "TipoPersonas", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persona", "TipoPersonas");
        }
    }
}
