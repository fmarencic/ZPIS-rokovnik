namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03012019 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.BROJNOSTANJE_VIEW",
            //    c => new
            //        {
            //            TIJELOID = c.Long(nullable: false, identity: true),
            //            NAZIVTIJELA = c.String(maxLength: 255),
            //            BROJZATVORENIKAMUSKI = c.Long(),
            //            BROJZATVORENIKAZENSKI = c.Long(),
            //            BROJISTRAZNIHZATVORENIKAMUSKI = c.Long(),
            //            BROJISTRAZNIHZATVORENIKAZENSKI = c.Long(),
            //            BROJKAZNJENIKAMUSKI = c.Long(),
            //            BROJKAZNJENIKAZENSKI = c.Long(),
            //            PROLAZNIMUSKU = c.Long(),
            //            NAIZLASKUMUSKI = c.Long(),
            //            NAIZLASKUZENSKI = c.Long(),
            //            UBIJEGUMUSKI = c.Long(),
            //            UBIJEGUZENSKI = c.Long(),
            //            NAPREKIDMUSKI = c.Long(),
            //            NAPREKIDZENSKI = c.Long(),
            //            KREIRAO = c.String(nullable: false, maxLength: 100),
            //            KREIRAOVRIJEME = c.DateTime(nullable: false),
            //            PROMIJENIO = c.String(maxLength: 100),
            //            PROMIJENIOVRIJEME = c.DateTime(),
            //            NAPOMENA = c.String(),
            //        })
            //    .PrimaryKey(t => t.TIJELOID);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.BROJNOSTANJE_VIEW");
        }
    }
}
