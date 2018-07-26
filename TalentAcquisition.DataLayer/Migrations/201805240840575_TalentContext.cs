namespace TalentAcquisition.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TalentContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobSeeker", "Email", c => c.String());
            AddColumn("dbo.Employee", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Email");
            DropColumn("dbo.JobSeeker", "Email");
        }
    }
}
