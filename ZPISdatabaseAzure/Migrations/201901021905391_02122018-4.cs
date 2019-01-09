namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _021220184 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PREDMET", "DATUMOSNIVANJA", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PREDMET", "DATUMOSNIVANJA", c => c.DateTime(nullable: false));
        }
    }
}
