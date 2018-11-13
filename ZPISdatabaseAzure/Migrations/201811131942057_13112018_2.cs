namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112018_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DOMENA",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VRSTADOMENE = c.String(),
                        NAZIV = c.String(),
                        OZNAKA = c.String(),
                        PARENTID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DOMENA", t => t.PARENTID)
                .Index(t => t.PARENTID);
            
            CreateTable(
                "dbo.KORISNIK",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        KORISNICKOIME = c.String(maxLength: 200),
                        LOZINKA = c.String(maxLength: 200),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KORISNIKULOGA",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
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
            DropForeignKey("dbo.DOMENA", "PARENTID", "dbo.DOMENA");
            DropIndex("dbo.DOMENA", new[] { "PARENTID" });
            DropTable("dbo.KORISNIKULOGA");
            DropTable("dbo.KORISNIK");
            DropTable("dbo.DOMENA");
        }
    }
}
