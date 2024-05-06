namespace _9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rates", "RateName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rates", "RateName");
        }
    }
}
