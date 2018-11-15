namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14112018_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UPISNIK", "TIJELOID", "dbo.DOMENA");
            DropIndex("dbo.UPISNIK", new[] { "TIJELOID" });
            CreateTable(
                "dbo.VRSTAUPISNIKA",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NAZIVGRUPE = c.String(maxLength: 200),
                        OZNAKA = c.String(maxLength: 255),
                        OZNAKABROJ = c.Long(nullable: false),
                        AKTIVAN = c.Boolean(nullable: false),
                        REDNIBROJ = c.Long(nullable: false),
                        PRIPADAVRSTIUPISNIKAID = c.Long(nullable: false),
                        KREIRAO = c.String(nullable: false, maxLength: 100),
                        KREIRAOVRIJEME = c.DateTime(nullable: false),
                        PROMIJENIO = c.String(maxLength: 100),
                        PROMIJENIOVRIJEME = c.DateTime(),
                        NAPOMENA = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VRSTAUPISNIKA", t => t.PRIPADAVRSTIUPISNIKAID)
                .Index(t => t.PRIPADAVRSTIUPISNIKAID);
            
            DropColumn("dbo.UPISNIK", "TIJELOID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UPISNIK", "TIJELOID", c => c.Long(nullable: false));
            DropForeignKey("dbo.VRSTAUPISNIKA", "PRIPADAVRSTIUPISNIKAID", "dbo.VRSTAUPISNIKA");
            DropIndex("dbo.VRSTAUPISNIKA", new[] { "PRIPADAVRSTIUPISNIKAID" });
            DropTable("dbo.VRSTAUPISNIKA");
            CreateIndex("dbo.UPISNIK", "TIJELOID");
            AddForeignKey("dbo.UPISNIK", "TIJELOID", "dbo.DOMENA", "ID", cascadeDelete: true);
        }
    }
}
