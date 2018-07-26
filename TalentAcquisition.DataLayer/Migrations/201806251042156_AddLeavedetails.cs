namespace TalentAcquisition.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeavedetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManageEmployeeLeave", "TotalLeaveTaken", c => c.Int());
            AddColumn("dbo.ManageEmployeeLeave", "TotalLeaveAvailable", c => c.Int());
            AlterColumn("dbo.ManageEmployeeLeave", "LeaveLimit", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ManageEmployeeLeave", "LeaveLimit", c => c.String());
            DropColumn("dbo.ManageEmployeeLeave", "TotalLeaveAvailable");
            DropColumn("dbo.ManageEmployeeLeave", "TotalLeaveTaken");
        }
    }
}
