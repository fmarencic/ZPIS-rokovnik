namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14112018_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DOKUMENTPISMENO", "DOKUMENTID", c => c.Long(nullable: false));
            CreateIndex("dbo.DOKUMENTPISMENO", "DOKUMENTID");
            AddForeignKey("dbo.DOKUMENTPISMENO", "DOKUMENTID", "dbo.DOKUMENT", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DOKUMENTPISMENO", "DOKUMENTID", "dbo.DOKUMENT");
            DropIndex("dbo.DOKUMENTPISMENO", new[] { "DOKUMENTID" });
            DropColumn("dbo.DOKUMENTPISMENO", "DOKUMENTID");
        }
    }
}
