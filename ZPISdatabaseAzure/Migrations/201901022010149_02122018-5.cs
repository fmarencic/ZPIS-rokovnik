namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _021220185 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DOKUMENT", "BROJSTRANICA", c => c.Long());
            AlterColumn("dbo.DOKUMENT", "DATUM", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DOKUMENT", "DATUM", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DOKUMENT", "BROJSTRANICA", c => c.Long(nullable: false));
        }
    }
}
