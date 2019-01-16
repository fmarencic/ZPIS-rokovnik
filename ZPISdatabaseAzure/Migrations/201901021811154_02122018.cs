namespace ZPISdatabaseAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02122018 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.VRSTAUPISNIKA", new[] { "PRIPADAVRSTIUPISNIKAID" });
            AlterColumn("dbo.VRSTAUPISNIKA", "PRIPADAVRSTIUPISNIKAID", c => c.Long());
            CreateIndex("dbo.VRSTAUPISNIKA", "PRIPADAVRSTIUPISNIKAID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.VRSTAUPISNIKA", new[] { "PRIPADAVRSTIUPISNIKAID" });
            AlterColumn("dbo.VRSTAUPISNIKA", "PRIPADAVRSTIUPISNIKAID", c => c.Long(nullable: false));
            CreateIndex("dbo.VRSTAUPISNIKA", "PRIPADAVRSTIUPISNIKAID");
        }
    }
}
