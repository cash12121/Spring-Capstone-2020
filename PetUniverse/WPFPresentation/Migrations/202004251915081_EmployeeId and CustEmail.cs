namespace WPFPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeIdandCustEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "CustEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CustEmail");
            DropColumn("dbo.AspNetUsers", "EmployeeID");
        }
    }
}
