namespace StayAlfredExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedidgeneration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Units");
            AlterColumn("dbo.Units", "UnitId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Units", "UnitId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Units");
            AlterColumn("dbo.Units", "UnitId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Units", "UnitId");
        }
    }
}
