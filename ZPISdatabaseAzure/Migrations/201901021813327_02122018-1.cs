namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _021220181 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VRSTAUPISNIKA", "REDNIBROJ", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VRSTAUPISNIKA", "REDNIBROJ", c => c.Long(nullable: false));
        }
    }
}
