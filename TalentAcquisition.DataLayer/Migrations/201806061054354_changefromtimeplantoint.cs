namespace TalentAcquisition.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefromtimeplantoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ManageEmployeeLeave", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ManageEmployeeLeave", "Duration", c => c.Time(nullable: false, precision: 7));
        }
    }
}
