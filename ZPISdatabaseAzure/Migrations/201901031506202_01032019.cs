namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01032019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OSOBA", "Spol", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OSOBA", "Spol");
        }
    }
}
