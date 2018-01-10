namespace AI_WoundAnalysisSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(),
                        UserRoleCode = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Telephone = c.String(),
                        Country = c.String(),
                        PostCode = c.String(),
                        Mobile = c.String(),
                        DOB = c.DateTime(),
                        DocumentPath = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedByID = c.Int(),
                        UserRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserRole", t => t.UserRoleID)
                .Index(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleID", "dbo.UserRole");
            DropIndex("dbo.Users", new[] { "UserRoleID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRole");
        }
    }
}
