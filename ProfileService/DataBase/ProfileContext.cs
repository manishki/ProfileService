using System.Data.Entity;

namespace ProfileService.DataBase
{
    public class ProfileContext : DbContext, IProfileContext
    {
        public ProfileContext() : base(nameOrConnectionString: "Default") { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}