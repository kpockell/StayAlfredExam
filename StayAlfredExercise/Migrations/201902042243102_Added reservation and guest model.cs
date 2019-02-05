namespace StayAlfredExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedreservationandguestmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestId = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GuestId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        GuestId = c.Guid(nullable: false),
                        UnitId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.GuestId)
                .Index(t => t.UnitId);
            
            AlterColumn("dbo.Buildings", "BuildingName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Reservations", "GuestId", "dbo.Guests");
            DropIndex("dbo.Reservations", new[] { "UnitId" });
            DropIndex("dbo.Reservations", new[] { "GuestId" });
            AlterColumn("dbo.Buildings", "BuildingName", c => c.String());
            DropTable("dbo.Reservations");
            DropTable("dbo.Guests");
        }
    }
}
