namespace BluTimesheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginingHour = c.Int(nullable: false),
                        BeginingMinute = c.Int(nullable: false),
                        EndingHour = c.Int(nullable: false),
                        EndingMinute = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ApprovedByManager = c.Boolean(nullable: false),
                        Activity_Id = c.Int(),
                        Project_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.Activity_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Activity_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectTypes", t => t.ProjectType_Id)
                .Index(t => t.ProjectType_Id);
            
            CreateTable(
                "dbo.ProjectTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        UserType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserType_Id)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropForeignKey("dbo.DailyActivities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DailyActivities", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectType_Id", "dbo.ProjectTypes");
            DropForeignKey("dbo.DailyActivities", "Activity_Id", "dbo.Activities");
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectType_Id" });
            DropIndex("dbo.DailyActivities", new[] { "User_Id" });
            DropIndex("dbo.DailyActivities", new[] { "Project_Id" });
            DropIndex("dbo.DailyActivities", new[] { "Activity_Id" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.ProjectTypes");
            DropTable("dbo.Projects");
            DropTable("dbo.DailyActivities");
            DropTable("dbo.Activities");
        }
    }
}