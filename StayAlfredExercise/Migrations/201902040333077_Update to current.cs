namespace StayAlfredExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatetocurrent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Units", "Building_BuildingId", "dbo.Buildings");
            DropIndex("dbo.Units", new[] { "Building_BuildingId" });
            AddColumn("dbo.Units", "SquareFootage", c => c.Int(nullable: false));
            AlterColumn("dbo.Units", "UnitNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Units", "Building_BuildingId", c => c.String(nullable: false, maxLength: 2));
            CreateIndex("dbo.Units", "Building_BuildingId");
            AddForeignKey("dbo.Units", "Building_BuildingId", "dbo.Buildings", "BuildingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "Building_BuildingId", "dbo.Buildings");
            DropIndex("dbo.Units", new[] { "Building_BuildingId" });
            AlterColumn("dbo.Units", "Building_BuildingId", c => c.String(maxLength: 2));
            AlterColumn("dbo.Units", "UnitNumber", c => c.String());
            DropColumn("dbo.Units", "SquareFootage");
            CreateIndex("dbo.Units", "Building_BuildingId");
            AddForeignKey("dbo.Units", "Building_BuildingId", "dbo.Buildings", "BuildingId");
        }
    }
}
