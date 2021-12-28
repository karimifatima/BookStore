namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImageName");
        }
    }
}
