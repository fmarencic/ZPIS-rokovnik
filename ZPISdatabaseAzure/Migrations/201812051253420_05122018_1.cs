namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05122018_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KORISNIKAUTH",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        KORISNIKID = c.Long(nullable: false),
                        AUTHTOKEN = c.String(maxLength: 255),
                        DATUM = c.DateTime(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KORISNIK", t => t.KORISNIKID, cascadeDelete: true)
                .Index(t => t.KORISNIKID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KORISNIKAUTH", "KORISNIKID", "dbo.KORISNIK");
            DropIndex("dbo.KORISNIKAUTH", new[] { "KORISNIKID" });
            DropTable("dbo.KORISNIKAUTH");
        }
    }
}
