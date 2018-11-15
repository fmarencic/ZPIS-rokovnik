namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14112018_5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DOKUMENT", "DATUM", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DOKUMENT", "DATUM");
        }
    }
}
