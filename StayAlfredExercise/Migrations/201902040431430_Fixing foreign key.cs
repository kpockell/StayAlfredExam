namespace StayAlfredExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixingforeignkey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Units", name: "Building_BuildingId", newName: "BuildingId");
            RenameIndex(table: "dbo.Units", name: "IX_Building_BuildingId", newName: "IX_BuildingId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Units", name: "IX_BuildingId", newName: "IX_Building_BuildingId");
            RenameColumn(table: "dbo.Units", name: "BuildingId", newName: "Building_BuildingId");
        }
    }
}
