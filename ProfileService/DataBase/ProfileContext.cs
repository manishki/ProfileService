using System.Data.Entity;

namespace ProfileService.DataBase
{
    public class ProfileContext : System.Data.Entity.DbContext
    {
        public ProfileContext() : base(nameOrConnectionString: "Default") { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}