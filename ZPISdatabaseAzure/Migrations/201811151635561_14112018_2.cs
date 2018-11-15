namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14112018_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UPISNIK", "TIJELOID", c => c.Long(nullable: false));
            CreateIndex("dbo.UPISNIK", "TIJELOID");
            AddForeignKey("dbo.UPISNIK", "TIJELOID", "dbo.OSOBA", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UPISNIK", "TIJELOID", "dbo.OSOBA");
            DropIndex("dbo.UPISNIK", new[] { "TIJELOID" });
            DropColumn("dbo.UPISNIK", "TIJELOID");
        }
    }
}
