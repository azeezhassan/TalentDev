namespace TalentAcquisition.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveApplicationmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveApplication",
                c => new
                    {
                        LeaveAppID = c.Int(nullable: false, identity: true),
                        LeavePlanID = c.Int(),
                        EmployeeId = c.String(),
                        EmployeeName = c.String(),
                        LeaveType = c.String(),
                        LeaveLimit = c.Int(),
                        TotalLeaveTaken = c.Int(),
                        TotalLeaveAvailable = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        ApplyDate = c.DateTime(nullable: false),
                        LeavePlanStatus = c.String(),
                        LeaveAppStatus = c.Int(nullable: false),
                        LeaveType_Limit_ID = c.Int(),
                    })
                .PrimaryKey(t => t.LeaveAppID)
                .ForeignKey("dbo.LeaveType_Limit", t => t.LeaveType_Limit_ID)
                .Index(t => t.LeaveType_Limit_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveApplication", "LeaveType_Limit_ID", "dbo.LeaveType_Limit");
            DropIndex("dbo.LeaveApplication", new[] { "LeaveType_Limit_ID" });
            DropTable("dbo.LeaveApplication");
        }
    }
}
