using System.Data.Entity;

namespace ProfileService.DataBase
{
    public interface IProfileContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
        void Dispose();

    }
}