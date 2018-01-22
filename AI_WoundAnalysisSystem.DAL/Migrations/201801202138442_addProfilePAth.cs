namespace AI_WoundAnalysisSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProfilePAth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfileImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ProfileImagePath");
        }
    }
}
