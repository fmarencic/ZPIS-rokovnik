namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112018_7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SUDIONIK",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PREDMETID = c.Long(nullable: false),
                        OSOBAID = c.Long(nullable: false),
                        ULOGA = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OSOBA", t => t.OSOBAID, cascadeDelete: true)
                .ForeignKey("dbo.PREDMET", t => t.PREDMETID)
                .ForeignKey("dbo.DOMENA", t => t.ULOGA)
                .Index(t => t.PREDMETID)
                .Index(t => t.OSOBAID)
                .Index(t => t.ULOGA);
            
            CreateTable(
                "dbo.KALENDAR",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        START = c.DateTime(),
                        KRAJ = c.DateTime(),
                        PREDMETID = c.Long(nullable: false),
                        KORISNIKID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KORISNIK", t => t.KORISNIKID, cascadeDelete: true)
                .ForeignKey("dbo.PREDMET", t => t.PREDMETID, cascadeDelete: true)
                .Index(t => t.PREDMETID)
                .Index(t => t.KORISNIKID);
            
            AddColumn("dbo.PISMENO", "PREDMETID", c => c.Long(nullable: false));
            AddColumn("dbo.PISMENO", "PISMENOVRSTAID", c => c.Long(nullable: false));
            AddColumn("dbo.KORISNIKULOGA", "ULOGAID", c => c.Long(nullable: false));
            AddColumn("dbo.KORISNIKULOGA", "KORISNIKID", c => c.Long(nullable: false));
            CreateIndex("dbo.PISMENO", "PREDMETID");
            CreateIndex("dbo.PISMENO", "PISMENOVRSTAID");
            CreateIndex("dbo.KORISNIKULOGA", "ULOGAID");
            CreateIndex("dbo.KORISNIKULOGA", "KORISNIKID");
            AddForeignKey("dbo.KORISNIKULOGA", "KORISNIKID", "dbo.KORISNIK", "ID", cascadeDelete: true);
            AddForeignKey("dbo.KORISNIKULOGA", "ULOGAID", "dbo.ULOGA", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PISMENO", "PISMENOVRSTAID", "dbo.PISMENOVRSTA", "ID");
            AddForeignKey("dbo.PISMENO", "PREDMETID", "dbo.PREDMET", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PISMENO", "PREDMETID", "dbo.PREDMET");
            DropForeignKey("dbo.PISMENO", "PISMENOVRSTAID", "dbo.PISMENOVRSTA");
            DropForeignKey("dbo.SUDIONIK", "ULOGA", "dbo.DOMENA");
            DropForeignKey("dbo.SUDIONIK", "PREDMETID", "dbo.PREDMET");
            DropForeignKey("dbo.KALENDAR", "PREDMETID", "dbo.PREDMET");
            DropForeignKey("dbo.KALENDAR", "KORISNIKID", "dbo.KORISNIK");
            DropForeignKey("dbo.KORISNIKULOGA", "ULOGAID", "dbo.ULOGA");
            DropForeignKey("dbo.KORISNIKULOGA", "KORISNIKID", "dbo.KORISNIK");
            DropForeignKey("dbo.SUDIONIK", "OSOBAID", "dbo.OSOBA");
            DropIndex("dbo.KORISNIKULOGA", new[] { "KORISNIKID" });
            DropIndex("dbo.KORISNIKULOGA", new[] { "ULOGAID" });
            DropIndex("dbo.KALENDAR", new[] { "KORISNIKID" });
            DropIndex("dbo.KALENDAR", new[] { "PREDMETID" });
            DropIndex("dbo.SUDIONIK", new[] { "ULOGA" });
            DropIndex("dbo.SUDIONIK", new[] { "OSOBAID" });
            DropIndex("dbo.SUDIONIK", new[] { "PREDMETID" });
            DropIndex("dbo.PISMENO", new[] { "PISMENOVRSTAID" });
            DropIndex("dbo.PISMENO", new[] { "PREDMETID" });
            DropColumn("dbo.KORISNIKULOGA", "KORISNIKID");
            DropColumn("dbo.KORISNIKULOGA", "ULOGAID");
            DropColumn("dbo.PISMENO", "PISMENOVRSTAID");
            DropColumn("dbo.PISMENO", "PREDMETID");
            DropTable("dbo.KALENDAR");
            DropTable("dbo.SUDIONIK");
        }
    }
}
