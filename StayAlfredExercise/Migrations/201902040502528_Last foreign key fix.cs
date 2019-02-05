namespace StayAlfredExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lastforeignkeyfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Units", "UnitId", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "UnitId", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
