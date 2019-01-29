namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28012019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PREDMET", "TIJELOID", c => c.Long());
            CreateIndex("dbo.PREDMET", "TIJELOID");
            AddForeignKey("dbo.PREDMET", "TIJELOID", "dbo.OSOBA", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PREDMET", "TIJELOID", "dbo.OSOBA");
            DropIndex("dbo.PREDMET", new[] { "TIJELOID" });
            DropColumn("dbo.PREDMET", "TIJELOID");
        }
    }
}
