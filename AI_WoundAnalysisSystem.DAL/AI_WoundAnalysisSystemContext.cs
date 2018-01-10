
namespace AI_WoundAnalysisSystem.DAL
{
    using AI_WoundAnalysisSystem.DTO;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class AI_WoundAnalysisSystemContext : DbContext
    {
        public AI_WoundAnalysisSystemContext()
            : base("name=AI_WoundAnalysisSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AI_WoundAnalysisSystemContext, Migrations.Configuration>());
        }

        #region Master tables    
        // public DbSet<UserType> UserTypes;
        #endregion

        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Master tables
            //modelBuilder.Entity<UserType>();
            #endregion

            modelBuilder.Entity<Users>();
            modelBuilder.Entity<UserRole>();
        }
    }
}
