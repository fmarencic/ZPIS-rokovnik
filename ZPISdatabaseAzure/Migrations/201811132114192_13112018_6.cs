namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112018_6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DOKUMENT",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        KLASIFIKACIJSKAOZNAKA = c.String(maxLength: 2000),
                        POSLOVNAOZNAKA = c.String(maxLength: 2000),
                        URUDZBENIBROJ = c.String(maxLength: 2000),
                        BROJSTRANICA = c.Long(nullable: false),
                        IMADIGITALIZIRANIDOKUMENT = c.Boolean(nullable: false),
                        IMARADNIDOKUMENT = c.Boolean(nullable: false),
                        DIGITALNIDOKUMENT = c.String(),
                        NAZIVDOKUMENTADMS = c.String(maxLength: 255),
                        SCHEMADOKUMENTAID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SCHEMADOKUMENTA", t => t.SCHEMADOKUMENTAID, cascadeDelete: true)
                .Index(t => t.SCHEMADOKUMENTAID);
            
            CreateTable(
                "dbo.SCHEMADOKUMENTA",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VERZIJA = c.Long(nullable: false),
                        JSONSCHEMA = c.String(),
                        NAZIVPREDLOSKADMS = c.String(maxLength: 255),
                        SCHEMAID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SCHEMA", t => t.SCHEMAID, cascadeDelete: true)
                .Index(t => t.SCHEMAID);
            
            CreateTable(
                "dbo.SCHEMA",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NAZIV = c.String(maxLength: 200),
                        OZNAKA = c.String(maxLength: 20),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DOKUMENT", "SCHEMADOKUMENTAID", "dbo.SCHEMADOKUMENTA");
            DropForeignKey("dbo.SCHEMADOKUMENTA", "SCHEMAID", "dbo.SCHEMA");
            DropIndex("dbo.SCHEMADOKUMENTA", new[] { "SCHEMAID" });
            DropIndex("dbo.DOKUMENT", new[] { "SCHEMADOKUMENTAID" });
            DropTable("dbo.SCHEMA");
            DropTable("dbo.SCHEMADOKUMENTA");
            DropTable("dbo.DOKUMENT");
        }
    }
}
