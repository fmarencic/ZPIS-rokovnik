namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112018_5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DOKUMENTPISMENO",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PISMENOID = c.Long(nullable: false),
                        VRSTADOKUMENTAUPISMENUID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PISMENO", t => t.PISMENOID, cascadeDelete: true)
                .ForeignKey("dbo.DOMENA", t => t.VRSTADOKUMENTAUPISMENUID, cascadeDelete: true)
                .Index(t => t.PISMENOID)
                .Index(t => t.VRSTADOKUMENTAUPISMENUID);
            
            CreateTable(
                "dbo.PISMENO",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        REDNIBROJ = c.Long(nullable: false),
                        NAZIVVRSTEPISMENA = c.String(maxLength: 255),
                        URBROJ = c.String(maxLength: 40),
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
            DropForeignKey("dbo.DOKUMENTPISMENO", "VRSTADOKUMENTAUPISMENUID", "dbo.DOMENA");
            DropForeignKey("dbo.DOKUMENTPISMENO", "PISMENOID", "dbo.PISMENO");
            DropIndex("dbo.DOKUMENTPISMENO", new[] { "VRSTADOKUMENTAUPISMENUID" });
            DropIndex("dbo.DOKUMENTPISMENO", new[] { "PISMENOID" });
            DropTable("dbo.PISMENO");
            DropTable("dbo.DOKUMENTPISMENO");
        }
    }
}
