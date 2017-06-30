namespace BungBungShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateForeignKeyForOrderDetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerMobile", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.OrderDetails", "ProductID");
            AddForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            AlterColumn("dbo.Orders", "CustomerMobile", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
