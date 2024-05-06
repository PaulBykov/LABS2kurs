namespace _9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rates", "RateName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rates", "RateName", c => c.String());
        }
    }
}
