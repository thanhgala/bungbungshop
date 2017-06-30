namespace BungBungShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Alias", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Image", c => c.String(maxLength: 256));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Image", c => c.String());
            AlterColumn("dbo.Products", "Alias", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
    }
}
