namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09012019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KALENDAR", "VRSTAKALENDARAID", c => c.Long());
            CreateIndex("dbo.KALENDAR", "VRSTAKALENDARAID");
            AddForeignKey("dbo.KALENDAR", "VRSTAKALENDARAID", "dbo.DOMENA", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KALENDAR", "VRSTAKALENDARAID", "dbo.DOMENA");
            DropIndex("dbo.KALENDAR", new[] { "VRSTAKALENDARAID" });
            DropColumn("dbo.KALENDAR", "VRSTAKALENDARAID");
        }
    }
}
