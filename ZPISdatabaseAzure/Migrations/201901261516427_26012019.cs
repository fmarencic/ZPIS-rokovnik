namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26012019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PREDMET", "STATUSPREDMETAID", c => c.Long());
            CreateIndex("dbo.PREDMET", "STATUSPREDMETAID");
            AddForeignKey("dbo.PREDMET", "STATUSPREDMETAID", "dbo.DOMENA", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PREDMET", "STATUSPREDMETAID", "dbo.DOMENA");
            DropIndex("dbo.PREDMET", new[] { "STATUSPREDMETAID" });
            DropColumn("dbo.PREDMET", "STATUSPREDMETAID");
        }
    }
}
