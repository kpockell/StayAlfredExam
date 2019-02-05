namespace StayAlfredExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcheckincheckoutdatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "CheckInDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "CheckOutDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "CheckOutDate");
            DropColumn("dbo.Reservations", "CheckInDate");
        }
    }
}
