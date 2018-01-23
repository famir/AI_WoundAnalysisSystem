namespace AI_WoundAnalysisSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woundTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wound",
                c => new
                    {
                        WoundId = c.Int(nullable: false, identity: true),
                        WoundTitle = c.String(),
                        Woundtype = c.String(),
                        SufferingFrom = c.DateTime(nullable: false),
                        WoundDetails = c.String(),
                        WoundImagePath = c.String(),
                        OriginalImage = c.String(),
                        SecondImage = c.String(),
                        EdgeDetectedImage = c.String(),
                        Threshold = c.Int(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WoundId)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wound", "UserID", "dbo.Users");
            DropIndex("dbo.Wound", new[] { "UserID" });
            DropTable("dbo.Wound");
        }
    }
}
