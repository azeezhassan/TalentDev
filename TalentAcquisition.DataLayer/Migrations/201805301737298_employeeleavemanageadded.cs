namespace TalentAcquisition.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeleavemanageadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManageEmployeeLeave",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(),
                        EmployeeName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        ApplyDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.EmployeeManageLeave");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeManageLeave",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(),
                        EmployeeName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.ManageEmployeeLeave");
        }
    }
}
