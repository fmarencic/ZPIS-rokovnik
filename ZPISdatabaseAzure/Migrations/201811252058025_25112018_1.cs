namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25112018_1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DOMENA", new[] { "PARENTID" });
            AlterColumn("dbo.DOMENA", "PARENTID", c => c.Long());
            CreateIndex("dbo.DOMENA", "PARENTID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DOMENA", new[] { "PARENTID" });
            AlterColumn("dbo.DOMENA", "PARENTID", c => c.Long(nullable: false));
            CreateIndex("dbo.DOMENA", "PARENTID");
        }
    }
}
