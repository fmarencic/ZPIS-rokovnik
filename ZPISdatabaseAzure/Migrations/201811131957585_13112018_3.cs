namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112018_3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OsobaEFs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        IME = c.String(maxLength: 255),
                        PREZIME = c.String(maxLength: 255),
                        NAZIV = c.String(maxLength: 255),
                        ADRESA = c.String(maxLength: 255),
                        EMAIL = c.String(maxLength: 255),
                        OIB = c.String(maxLength: 11),
                        VRSTAOSOBEID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DOMENA", t => t.VRSTAOSOBEID, cascadeDelete: true)
                .Index(t => t.VRSTAOSOBEID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OsobaEFs", "VRSTAOSOBEID", "dbo.DOMENA");
            DropIndex("dbo.OsobaEFs", new[] { "VRSTAOSOBEID" });
            DropTable("dbo.OsobaEFs");
        }
    }
}
