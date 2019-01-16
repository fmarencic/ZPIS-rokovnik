namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _030120191 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KORISNIK", "ZAPOSLENNATIJELIMA", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KORISNIK", "ZAPOSLENNATIJELIMA");
        }
    }
}
