namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Summary = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffPicBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        StaffPicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.StaffPicId })
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.StaffPics", t => t.StaffPicId)
                .Index(t => t.BookId)
                .Index(t => t.StaffPicId);
            
            CreateTable(
                "dbo.StaffPics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffPicBooks", "StaffPicId", "dbo.StaffPics");
            DropForeignKey("dbo.StaffPicBooks", "BookId", "dbo.Books");
            DropIndex("dbo.StaffPicBooks", new[] { "StaffPicId" });
            DropIndex("dbo.StaffPicBooks", new[] { "BookId" });
            DropTable("dbo.StaffPics");
            DropTable("dbo.StaffPicBooks");
            DropTable("dbo.Books");
        }
    }
}
