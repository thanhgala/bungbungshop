namespace BungBungShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStatusInPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Status");
        }
    }
}
