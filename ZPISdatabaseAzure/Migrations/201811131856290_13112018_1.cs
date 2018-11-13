namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13112018_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ULOGA",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NAZIV = c.String(maxLength: 200),
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
            DropTable("dbo.ULOGA");
        }
    }
}
