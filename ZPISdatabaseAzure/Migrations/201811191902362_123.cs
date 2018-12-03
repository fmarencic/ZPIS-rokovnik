namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OSOBA", "PUNINAZIVOSOBE", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OSOBA", "PUNINAZIVOSOBE");
        }
    }
}
