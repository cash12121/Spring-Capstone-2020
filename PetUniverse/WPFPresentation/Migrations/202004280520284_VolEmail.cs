namespace WPFPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VolEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "VolEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "VolEmail");
        }
    }
}
