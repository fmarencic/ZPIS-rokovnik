namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14112018_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SUDIONIK", "REDNIBROJ", c => c.Long(nullable: false));
            AddColumn("dbo.OSOBAFOTOGRAFIJE", "OSOBAID", c => c.Long(nullable: false));
            CreateIndex("dbo.OSOBAFOTOGRAFIJE", "OSOBAID");
            AddForeignKey("dbo.OSOBAFOTOGRAFIJE", "OSOBAID", "dbo.OSOBA", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OSOBAFOTOGRAFIJE", "OSOBAID", "dbo.OSOBA");
            DropIndex("dbo.OSOBAFOTOGRAFIJE", new[] { "OSOBAID" });
            DropColumn("dbo.OSOBAFOTOGRAFIJE", "OSOBAID");
            DropColumn("dbo.SUDIONIK", "REDNIBROJ");
        }
    }
}
