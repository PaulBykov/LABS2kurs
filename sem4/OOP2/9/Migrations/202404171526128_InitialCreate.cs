namespace _9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        ComputerId = c.Int(nullable: false, identity: true),
                        IsFree = c.Boolean(nullable: false),
                        RateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComputerId)
                .ForeignKey("dbo.Rates", t => t.RateId, cascadeDelete: true)
                .Index(t => t.RateId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        Multiplier = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.RateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computers", "RateId", "dbo.Rates");
            DropIndex("dbo.Computers", new[] { "RateId" });
            DropTable("dbo.Rates");
            DropTable("dbo.Computers");
        }
    }
}
