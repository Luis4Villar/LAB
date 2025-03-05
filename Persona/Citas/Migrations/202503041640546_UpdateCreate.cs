namespace Citas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cita", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cita", "Estado");
        }
    }
}
