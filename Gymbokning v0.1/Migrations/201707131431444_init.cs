namespace Gymbokning_v0._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TimeOfRegistration", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "TimeOfRegistration_CommandTimeout");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "TimeOfRegistration_CommandTimeout", c => c.Int());
            DropColumn("dbo.AspNetUsers", "TimeOfRegistration");
        }
    }
}
