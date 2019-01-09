namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _021220183 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PISMENOVRSTA", "SCHEMAID", c => c.Long(nullable: false));
            CreateIndex("dbo.PISMENOVRSTA", "SCHEMAID");
            AddForeignKey("dbo.PISMENOVRSTA", "SCHEMAID", "dbo.SCHEMA", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PISMENOVRSTA", "SCHEMAID", "dbo.SCHEMA");
            DropIndex("dbo.PISMENOVRSTA", new[] { "SCHEMAID" });
            DropColumn("dbo.PISMENOVRSTA", "SCHEMAID");
        }
    }
}
