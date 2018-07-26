namespace TalentAcquisition.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeaveType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveType_Limit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LeaveType = c.String(),
                        Limit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ManageEmployeeLeave", "LeaveType", c => c.String());
            AddColumn("dbo.ManageEmployeeLeave", "LeaveLimit", c => c.String());
            AddColumn("dbo.ManageEmployeeLeave", "LeaveType_Limit_ID", c => c.Int());
            CreateIndex("dbo.ManageEmployeeLeave", "LeaveType_Limit_ID");
            AddForeignKey("dbo.ManageEmployeeLeave", "LeaveType_Limit_ID", "dbo.LeaveType_Limit", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManageEmployeeLeave", "LeaveType_Limit_ID", "dbo.LeaveType_Limit");
            DropIndex("dbo.ManageEmployeeLeave", new[] { "LeaveType_Limit_ID" });
            DropColumn("dbo.ManageEmployeeLeave", "LeaveType_Limit_ID");
            DropColumn("dbo.ManageEmployeeLeave", "LeaveLimit");
            DropColumn("dbo.ManageEmployeeLeave", "LeaveType");
            DropTable("dbo.LeaveType_Limit");
        }
    }
}
