namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _021220182 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UPISNIK", "VRSTAUPISNIKAID", c => c.Long(nullable: false));
            CreateIndex("dbo.UPISNIK", "VRSTAUPISNIKAID");
            AddForeignKey("dbo.UPISNIK", "VRSTAUPISNIKAID", "dbo.VRSTAUPISNIKA", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UPISNIK", "VRSTAUPISNIKAID", "dbo.VRSTAUPISNIKA");
            DropIndex("dbo.UPISNIK", new[] { "VRSTAUPISNIKAID" });
            DropColumn("dbo.UPISNIK", "VRSTAUPISNIKAID");
        }
    }
}
