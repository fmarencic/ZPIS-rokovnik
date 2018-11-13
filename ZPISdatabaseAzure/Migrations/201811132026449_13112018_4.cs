namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112018_4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OsobaEFs", newName: "OSOBA");
            CreateTable(
                "dbo.OSOBAFOTOGRAFIJE",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FOTOGRAFIJA = c.String(),
                        TIP = c.String(maxLength: 255),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PISMENOVRSTA",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AKTIVAN = c.Boolean(nullable: false),
                        OZNAKA = c.String(maxLength: 255),
                        NAZIV = c.String(maxLength: 255),
                        NAZIVZADOSTAVNICU = c.String(maxLength: 200),
                        NAZIVVRSTEPISMENA = c.String(maxLength: 255),
                        GRUPAID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DOMENA", t => t.GRUPAID, cascadeDelete: true)
                .Index(t => t.GRUPAID);
            
            CreateTable(
                "dbo.PREDMET",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        REDNIBROJ = c.Long(nullable: false),
                        NAZIV = c.String(maxLength: 255),
                        DATUMOSNIVANJA = c.DateTime(nullable: false),
                        OZNAKAPREDMETA = c.String(maxLength: 255),
                        UPISNIKID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UPISNIK", t => t.UPISNIKID, cascadeDelete: true)
                .Index(t => t.UPISNIKID);
            
            CreateTable(
                "dbo.UPISNIK",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NAZIV = c.String(maxLength: 255),
                        OZNAKA = c.String(maxLength: 255),
                        GODINA = c.Long(nullable: false),
                        AKTIVAN = c.Boolean(nullable: false),
                        TIJELOID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DOMENA", t => t.TIJELOID, cascadeDelete: true)
                .Index(t => t.TIJELOID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PREDMET", "UPISNIKID", "dbo.UPISNIK");
            DropForeignKey("dbo.UPISNIK", "TIJELOID", "dbo.DOMENA");
            DropForeignKey("dbo.PISMENOVRSTA", "GRUPAID", "dbo.DOMENA");
            DropIndex("dbo.UPISNIK", new[] { "TIJELOID" });
            DropIndex("dbo.PREDMET", new[] { "UPISNIKID" });
            DropIndex("dbo.PISMENOVRSTA", new[] { "GRUPAID" });
            DropTable("dbo.UPISNIK");
            DropTable("dbo.PREDMET");
            DropTable("dbo.PISMENOVRSTA");
            DropTable("dbo.OSOBAFOTOGRAFIJE");
            RenameTable(name: "dbo.OSOBA", newName: "OsobaEFs");
        }
    }
}
