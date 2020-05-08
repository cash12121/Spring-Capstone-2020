namespace WPFPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepoFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        ItemID = c.Int(nullable: false),
                        Taxable = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        Name = c.String(),
                        Category = c.String(),
                        Type = c.String(),
                        Description = c.String(),
                        Brand = c.String(),
                        ItemName = c.String(),
                        ItemQuantity = c.Int(),
                        Quantity = c.Int(),
                        ItemDescription = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
